﻿namespace CarQuest.Web.Infrastructure.Middlewares;

using System.Collections.Concurrent;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

using static Common.GeneralApplicationConstants;

public class OnlineUserMiddleware
{
	private readonly RequestDelegate next;
	private readonly string cookieName;
	private readonly int lastActivityMinutes;

	private static readonly ConcurrentDictionary<string, bool> AllKeys =
		new();

	public OnlineUserMiddleware(RequestDelegate next,
		string cookieName = OnlineUsersCookieName,
		int lastActivityMinutes = LastActivityBeforeofflineMinutes)
	{
		this.next = next;
		this.cookieName = cookieName;
		this.lastActivityMinutes = lastActivityMinutes;
	}

	public Task InvokeAsync(HttpContext context, IMemoryCache memoryCache)
	{
		if (context.User.Identity?.IsAuthenticated ?? false)
		{
			if (!context.Request.Cookies.TryGetValue(cookieName, out string userId))
			{
				userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

				context.Response.Cookies.Append(cookieName, userId, new CookieOptions
				{
					HttpOnly = true,
					MaxAge = TimeSpan.FromDays(3)
				});

				memoryCache.GetOrCreate(userId, cacheEntry =>
				{
					if (!AllKeys.TryAdd(userId, true))
					{
						cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
					}
					else
					{
						cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(lastActivityMinutes);
						cacheEntry.RegisterPostEvictionCallback(RemoveKeyWhenExpired);
					}

					return string.Empty;
				});
			}
		}
		else
		{
			if (context.Request.Cookies.TryGetValue(cookieName, out string userId))
			{
				if (!AllKeys.TryRemove(userId, out _))
				{
					AllKeys.TryUpdate(userId, false, true);
				}

				context.Response.Cookies.Delete(cookieName);
			}
		}

		return next(context);
	}

	public static bool CheckIfUserIsOnline(string userId)
	{
		bool valueTaken = AllKeys.TryGetValue(userId.ToLower(), out bool success);

		return success && valueTaken;
	}

	private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
	{
		string keyStr = (string)key;

		if (!AllKeys.TryRemove(keyStr, out _))
		{
			AllKeys.TryUpdate(keyStr, false, true);
		}
	}
}
