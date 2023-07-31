namespace CarQuest.Common;

using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class YearRangeAttribute : RangeAttribute
{
	public YearRangeAttribute(int minimum) : base(minimum, DateTime.Now.Year)
	{
	}
}