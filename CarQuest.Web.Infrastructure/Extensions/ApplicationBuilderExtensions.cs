namespace CarQuest.Web.Infrastructure.Extensions;

using Data.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Middlewares;
using static Common.GeneralApplicationConstants;

public static class ApplicationBuilderExtensions
{
	public static IApplicationBuilder SeedAdministration(this IApplicationBuilder app, string email)
	{
		using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

		IServiceProvider serviceProvider = scopedServices.ServiceProvider;

		UserManager<ApplicationUser> userManager =
			serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
		RoleManager<IdentityRole<Guid>> roleManager =
			serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

		Task.Run(async () =>
		{
			if (await roleManager.RoleExistsAsync(AdminRoleName))
			{
				return;
			}

			IdentityRole<Guid> role = new(AdminRoleName);

			await roleManager.CreateAsync(role);

			ApplicationUser adminUser =
				await userManager.FindByEmailAsync(email);

			await userManager.AddToRoleAsync(adminUser, AdminRoleName);
		})
			.GetAwaiter()
			.GetResult();

		return app;
	}

	public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder app)
	{
		return app.UseMiddleware<OnlineUserMiddleware>();
	}
}
