namespace CarQuest.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
	public void Configure(EntityTypeBuilder<Ticket> builder)
	{
		builder
			.HasOne(t => t.Car)
			.WithMany(c => c.Tickets)
			.HasForeignKey(t => t.CarId)
			.OnDelete(DeleteBehavior.NoAction)
			.HasConstraintName("FK_Ticket_Cars_CarId");
	}
}
