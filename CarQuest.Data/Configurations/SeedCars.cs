namespace CarQuest.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class SeedCars : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.HasData(new Car
		{
			Id = Guid.Parse("78ACC508-53B5-4976-A07A-C0A8BA9EA0C8"),
			Model = "Focus",
			Brand = "Ford",
			Year = "2012",
			Mileage = "100000",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE",
			OwnerId = Guid.Parse("CE0B3F5F-5558-43E9-B1B9-07B8F4451DF2")
		});
	}
}
