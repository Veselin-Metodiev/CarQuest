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
			.OnDelete(DeleteBehavior.NoAction);

		builder
			.HasOne(t => t.Offer)
			.WithOne(c => c.Ticket)
			.OnDelete(DeleteBehavior.NoAction);

		builder
			.HasOne(t => t.Owner)
			.WithMany(c => c.Tickets)
			.HasForeignKey(t => t.OwnerId);

		builder
			.HasOne(t => t.AssignedMechanic)
			.WithMany(c => c.Tickets)
			.HasForeignKey(t => t.AssignedMechanicId);
	}
}
