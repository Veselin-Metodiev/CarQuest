namespace CarQuest.Common;

public static class NotificationMessagesConstants
{
	public const string ErrorMessage = "ErrorMessage";
	public const string WarningMessage = "WarnMessage";
	public const string InformationMessage = "InfoMessage";
	public const string SuccessMessage = "SuccessMessage";

	public const string MustBeMechanicError = "You must be a mechanic to perform this action";
	public const string MustNotBeMechanicError = "You must not be a mechanic to perform this action";
	public const string MustBeOwnerError = "You must be the owner of this item to perform this action";
	public const string AlreadyMechanicError = "You are already a mechanic";
	public const string PhoneNumberAlreadyExists = "Mechanic with the provided phone number already exists!";
	public const string ExistingTicketsError = "You must not have any active tickets to be a mechanic";
	public const string TicketAlreadyTackenError = "Ticket is already taken";
	public const string MustBeAssignedMechanicError = "You must be the assigned mechanic to perform this action";
}
