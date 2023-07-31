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
}
