using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain;

namespace ParkingManagement.Infrastructure.Persistence.Configurations
{
    public class ParkingSpotConfiguration : IEntityTypeConfiguration<ParkingSpot>
    {
        public void Configure(EntityTypeBuilder<ParkingSpot> builder)
        {
            builder.ToTable("ParkingSpots");

            builder.HasKey(ps => ps.Id);

            builder.Property(ps => ps.SpotNumber)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasIndex(ps => ps.SpotNumber)
                   .IsUnique();

            builder.Property(ps => ps.Zone)
                   .HasMaxLength(50);

            builder.Property(ps => ps.Type)
                   .IsRequired()
                   .HasConversion<string>();

            builder.Property(ps => ps.IsAvailable)
                   .IsRequired();

            builder.Property(ps => ps.LastOccupiedTime)
                   .HasColumnType("datetime2");

            builder.Property(ps => ps.LastVacatedTime)
                   .HasColumnType("datetime2");

            builder.HasMany(ps => ps.ParkingLogs)
                   .WithOne(pl => pl.ParkingSpot)
                   .HasForeignKey(pl => pl.ParkingSpotId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}