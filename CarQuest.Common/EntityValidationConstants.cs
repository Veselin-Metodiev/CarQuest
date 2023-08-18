namespace CarQuest.Common;

public static class EntityValidationConstants
{
    public class Car
    {
        public const int BrandMaxLength = 50;

        public const int ModelMaxLength = 100;

        public const int YearMaxLength = 4;

        public const int CarImageUrlMaxLength = 300;

        public const int MileageMaxLength = 7;
    }

    public class CarViewModel
    {
	    public const int BrandMaxLength = 50;
	    public const int BrandMinLength = 1;

	    public const int ModelMaxLength = 100;
	    public const int ModelMinLength = 1;

	    public const int CarImageUrlMaxLength = 300;
	    public const int CarImageUrlMinLength = 10;

	    public const long MileageMaxValue = 10000000;
	    public const int MileageMinValue = 1;

	    public const int CategoriesMaxLength = 50;
	    public const int CategoriesMinLength = 1;

	    public const int YearMinValue = 1900;
    }

    public class Offer
    {
	    public const int TitleMaxLength = 50;
	    public const int DescriptionMaxLength = 200;
    }

    public class OfferAddViewModel
    {
	    public const int TitleMaxLength = 50;
	    public const int TitleMinLength = 5;

	    public const int DescriptionMaxLength = 200;
	    public const int DescriptionMinLength = 10;

	    public const int HoursMaxLength = 24;
        public const int HoursMinLength = 1;

        public const int DaysMaxLength = 100;
        public const int DaysMinLength = 0;

        public const int CostMinLength = 1;
        public const int CostMaxLength = int.MaxValue;
    }

    public class ApplicationUser
    {
	    public const int FirstNameMaxLength = 50;

	    public const int LastNameMaxLength = 50;
    }

    public class Mechanic
    {
	    public const int PhoneNumberMaxLength = 13;

	    public const int ShopAddressMaxLength = 100;
    }

    public class Ticket
    {
        public const int TitleMaxLength = 50;

        public const int DescriptionMaxLength = 500;
    }

    public class MechanicBecomeViewModel
    {
	    public const int PhoneNumberMaxLength = 13;
	    public const int PhoneNumberMinLength = 10;

	    public const int ShopAddressMaxLength = 500;
	    public const int ShopAddressMinLength = 10;
    }

    public class TicketAddAndUpdateViewModel
    {
	    public const int TitleMaxLength = 50;
        public const int TitleMinLength = 5;

	    public const int DescriptionMaxLength = 500;
        public const int DescriptionMinLength = 5;
    }

    public class Category
    {
	    public const int NameMaxLength = 50;
    }
}
