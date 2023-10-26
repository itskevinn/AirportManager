using Domain.Constants.Enum;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.FlightStatus)
            .HasConversion(
                v => v.ToString(),
                v => (FlightStatus)Enum.Parse(typeof(FlightStatus), v))
            .IsRequired();
        builder.Property(f => f.CheckInTime).IsRequired();
        builder.Property(f => f.CheckOutTime).IsRequired();
        builder.Property(f => f.CheckOutDate).IsRequired();
        builder.HasOne(f => f.Airline).WithMany().HasForeignKey(f => f.AirlineId);
        builder.HasOne(f => f.DepartureCity).WithMany().HasForeignKey(f => f.DepartureCityId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(f => f.DestinyCity).WithMany().HasForeignKey(f => f.DestinyCityId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Property(f => f.UpdatedBy).IsRequired(false);
        builder.Property(f => f.LastModifiedOn).IsRequired(false);
    }
}