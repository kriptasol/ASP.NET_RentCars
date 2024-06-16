using System.Collections.Generic;
using System.Formats.Asn1;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;


using Carss.Models;

namespace Carss
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarRentNow> CarRentNows { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.UserEmail).IsRequired().HasMaxLength(255);
                entity.Property(e => e.UserPassword).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.UserEmail).IsUnique();
            });

            modelBuilder.Entity<Transmission>(entity =>
            {
                entity.HasKey(e => e.TransmId);
                entity.Property(e => e.TransmId).ValueGeneratedOnAdd();
                entity.Property(e => e.Transm).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<CarClass>(entity =>
            {
                entity.HasKey(e => e.ClassId);
                entity.Property(e => e.ClassId).ValueGeneratedOnAdd();
                entity.Property(e => e.ClassName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarId);
                entity.Property(e => e.CarId).ValueGeneratedOnAdd();
                entity.Property(e => e.CarName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.CarNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CostPerDay).HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(e => e.EngineCapacity).HasColumnType("decimal(3,1)").IsRequired();
                entity.Property(e => e.Fuel).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.CarNumber).IsUnique();

                entity.HasOne(e => e.Transmission)
                    .WithMany(t => t.Cars)
                    .HasForeignKey(e => e.TransmissionId);

                entity.HasOne(e => e.CarClass)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(e => e.ClassId);
            });

            modelBuilder.Entity<CarRentNow>(entity =>
            {
                entity.HasKey(e => e.RentId);
                entity.Property(e => e.RentId).ValueGeneratedOnAdd();
                entity.Property(e => e.TimeStart).IsRequired();
                entity.Property(e => e.TimeEnd).IsRequired();
                entity.Property(e => e.RentDay).IsRequired();
                entity.Property(e => e.CostAllTime).HasColumnType("decimal(10,2)").IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.CarRentNows)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Car)
                    .WithMany(c => c.CarRentNows)
                    .HasForeignKey(e => e.CarId);
            });
        }
    }
}
