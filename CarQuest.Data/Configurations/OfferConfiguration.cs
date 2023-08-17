namespace CarQuest.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
	public void Configure(EntityTypeBuilder<Offer> builder)
	{
		builder.Property(o => o.Cost)
			.HasPrecision(18, 2);

		builder.Property(o => o.HasUserAccepted)
			.HasDefaultValue(false);
	}
}
