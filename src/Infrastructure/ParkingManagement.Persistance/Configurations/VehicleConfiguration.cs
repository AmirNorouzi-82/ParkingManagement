using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain;

namespace ParkingManagement.Infrastructure.Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            
            builder.ToTable("Vehicles");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.PlateNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(v => v.PlateNumber)
                   .IsUnique();

            builder.Property(v => v.Make)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.Model)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.Color)
                   .HasMaxLength(30);

            builder.Property(v => v.OwnerName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(v => v.PhoneNumber)
                   .HasMaxLength(20);

            builder.HasMany(v => v.ParkingLogs)
                   .WithOne(pl => pl.Vehicle)
                   .HasForeignKey(pl => pl.VehicleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}