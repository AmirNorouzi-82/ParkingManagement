using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain;
using ParkingManagement.Domain.Enums;

namespace ParkingManagement.Infrastructure.Persistence.Configurations
{
    public class ParkingLogConfiguration : IEntityTypeConfiguration<ParkingLog>
    {
        public void Configure(EntityTypeBuilder<ParkingLog> builder)
        {
            builder.ToTable("ParkingLogs");

            builder.HasKey(pl => pl.Id);

            builder.Property(pl => pl.EntryTime)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(pl => pl.ExitTime)
                   .HasColumnType("datetime2");

            builder.Property(pl => pl.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasDefaultValue(PaymentStatus.Pending);

            builder.Property(pl => pl.Cost)
                   .HasPrecision(18, 2);

            builder.Property(pl => pl.Notes)
                   .HasMaxLength(500);

            builder.Property(pl => pl.AdminId)
                   .IsRequired(false);

            builder.HasOne(pl => pl.Vehicle)
                   .WithMany(v => v.ParkingLogs)
                   .HasForeignKey(pl => pl.VehicleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pl => pl.ParkingSpot)
                   .WithMany(ps => ps.ParkingLogs)
                   .HasForeignKey(pl => pl.ParkingSpotId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pl => pl.Admin)
                   .WithMany(a => a.ParkingLogs)
                   .HasForeignKey(pl => pl.AdminId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}