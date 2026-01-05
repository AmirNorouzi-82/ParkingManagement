using ParkingManagement.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ParkingManagement.Persistance.Contexts
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingLog> ParkingLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Admin configurations
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(a => a.Username).IsUnique();
                entity.HasIndex(a => a.Email).IsUnique();
                entity.Property(a => a.Username).HasMaxLength(100);
                entity.Property(a => a.PasswordHash).HasMaxLength(500); // Increased for salt:hash storage
                entity.Property(a => a.Email).HasMaxLength(150);
                entity.Property(a => a.FullName).HasMaxLength(50);
                entity.Property(a => a.CreatedAt).HasColumnType("datetime2");
                entity.Property(a => a.LastLogin).HasColumnType("datetime2");
            });

            // Vehicle configurations
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(v => v.PlateNumber).IsUnique();
                entity.Property(v => v.PlateNumber).HasMaxLength(20);
                entity.Property(v => v.Make).HasMaxLength(50);
                entity.Property(v => v.Model).HasMaxLength(50);
                entity.Property(v => v.Color).HasMaxLength(20);
                entity.Property(v => v.OwnerName).HasMaxLength(50);
                entity.Property(v => v.PhoneNumber).HasMaxLength(20);
                entity.Property(v => v.RegisteredAt).HasColumnType("datetime2");
            });

            // ParkingSpot configurations
            modelBuilder.Entity<ParkingSpot>(entity =>
            {
                entity.HasIndex(ps => ps.SpotNumber).IsUnique();
                entity.Property(ps => ps.SpotNumber).HasMaxLength(10);
                entity.Property(ps => ps.Zone).HasMaxLength(50);
                entity.Property(ps => ps.Type).HasConversion<string>();
                entity.Property(ps => ps.LastOccupiedTime).HasColumnType("datetime2");
                entity.Property(ps => ps.LastVacatedTime).HasColumnType("datetime2");
            });

            // ParkingLog configurations
            modelBuilder.Entity<ParkingLog>(entity =>
            {
                
                entity.Property(pl => pl.Cost)
                    .HasPrecision(18, 2) 
                    .HasColumnType("decimal(18,2)");

                entity.Property(pl => pl.EntryTime).HasColumnType("datetime2");
                entity.Property(pl => pl.ExitTime).HasColumnType("datetime2");
                entity.Property(pl => pl.Status).HasConversion<string>();
                entity.Property(pl => pl.Notes).HasMaxLength(500);

                
                entity.HasOne(pl => pl.Vehicle)
                    .WithMany(v => v.ParkingLogs)
                    .HasForeignKey(pl => pl.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pl => pl.ParkingSpot)
                    .WithMany(ps => ps.ParkingLogs)
                    .HasForeignKey(pl => pl.ParkingSpotId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pl => pl.Admin)
                    .WithMany(a => a.ParkingLogs)
                    .HasForeignKey(pl => pl.AdminId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
