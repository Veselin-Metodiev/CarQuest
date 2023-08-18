namespace CarQuest.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Models.Enums;

public class SeedTickets : IEntityTypeConfiguration<Ticket>
{
	public void Configure(EntityTypeBuilder<Ticket> builder)
	{
		builder.HasData(new Ticket
		{
			Id = Guid.Parse("3E01B97F-98E4-421F-8552-2159301E1D15"),
			Title = "Test Title",
			Description = "Test Description",
			CarId = Guid.Parse("78ACC508-53B5-4976-A07A-C0A8BA9EA0C8"),
			OwnerId = Guid.Parse("CE0B3F5F-5558-43E9-B1B9-07B8F4451DF2"),
			AssignedMechanicId = Guid.Parse("56942F96-8E95-472E-A5CD-471146BBBB75"),
			Status = Status.Taken
		});
	}
}
