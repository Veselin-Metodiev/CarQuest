namespace CarQuest.Common;

public static class EntityValidationConstants
{
    public class Car
    {
        public const int BrandMaxLength = 50;

        public const int ModelMaxLength = 100;

        public const int YearMaxLength = 4;

        public const int MileageMaxLength = 7;
    }

    public class CarViewModel
    {
	    public const int BrandMaxLength = 50;
	    public const int BrandMinLength = 1;

	    public const int ModelMaxLength = 100;
	    public const int ModelMinLength = 1;

	    public const int YearMinValue = 1900;

	    public const long MileageMaxValue = 10000000;
	    public const int MileageMinValue = 1;
    }

    public class ApplicationUser
    {
	    public const int FirstNameMaxLength = 50;

	    public const int LastNameMaxLength = 50;
    }

    public class Mechanic
    {
	    public const int PhoneNumberMaxLength = 20;

	    public const int ShopAddressMaxLength = 100;
    }

    public class Ticket
    {
        public const int TitleMaxLength = 50;

        public const int DescriptionMaxLength = 500;
    }

    public class MechanicBecomeViewModel
    {
	    public const int PhoneNumberMaxLength = 20;
	    public const int PhoneNumberMinLength = 10;

	    public const int ShopAddressMaxLength = 500;
	    public const int ShopAddressMinLength = 10;
    }
}
