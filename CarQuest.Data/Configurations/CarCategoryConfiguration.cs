namespace CarQuest.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

public class CarCategoryConfiguration : IEntityTypeConfiguration<CarCategory>
{
	public void Configure(EntityTypeBuilder<CarCategory> builder)
	{
		builder.HasKey(pk => new { pk.CarId, pk.CategoryId });
	}
}
