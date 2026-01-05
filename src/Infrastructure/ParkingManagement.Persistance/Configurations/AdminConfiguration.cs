using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain;

namespace ParkingManagement.Infrastructure.Persistence.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Username)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(a => a.Username)
                   .IsUnique();

            builder.Property(a => a.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(a => a.Email)
                   .IsUnique();

            builder.Property(a => a.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(a => a.FullName)
                   .HasMaxLength(50);

            builder.Property(a => a.CreatedAt)
                   .HasColumnType("datetime2");

            builder.Property(a => a.LastLogin)
                   .HasColumnType("datetime2");

            builder.HasMany(a => a.ParkingLogs)
                   .WithOne(pl => pl.Admin)
                   .HasForeignKey(pl => pl.AdminId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}