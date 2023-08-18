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
			ImageUrl = "https://www.cnet.com/a/img/resize/9d18bb42850bdb40a537ff761ff96129d4aab5e1/hub/2011/04/18/35e87d3a-f0f5-11e2-8c7c-d4ae52e62bcc/34641485_OVR_1.jpg?auto=webp&width=1200",
			OwnerId = Guid.Parse("CE0B3F5F-5558-43E9-B1B9-07B8F4451DF2")
		});
	}
}
