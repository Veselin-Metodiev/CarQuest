namespace CarQuest.Common;

public class GeneralApplicationConstants
{
	public const string AdminRoleName = "Administrator";
	public const string DevelopmentAdminEmail = "admin@carquest.com";
	public const string AdminAreaName = "Admin";

	public const string OnlineUsersCookieName = "IsOnline";
	public const int LastActivityBeforeofflineMinutes = 10;

	public const string UsersCacheKey = "UsersCache";
	public const string MechanicsCacheKey = "MechanicsCache";
	public const string TicketsCacheKey = "TicketsCache";

	public const int UsersCacheDurationMinutes = 5;
}