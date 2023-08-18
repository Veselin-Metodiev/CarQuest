namespace CarQuest.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class SeedMechanic : IEntityTypeConfiguration<Mechanic>
{
	public void Configure(EntityTypeBuilder<Mechanic> builder)
	{
		builder.HasData(new Mechanic
		{
			Id = Guid.Parse("56942F96-8E95-472E-A5CD-471146BBBB75"),
			UserId = Guid.Parse("CE0B3F5F-5558-43E9-B1B9-07B8F4451DF2"),
			PhoneNumber = "+359888888888",
			ShopAddress = "Test Address"
		});
	}
}
