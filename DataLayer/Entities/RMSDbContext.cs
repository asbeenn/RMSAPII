using DataLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Common;
using Microsoft.Extensions.Options;

namespace DataLayer.Entities
{
    public partial class RMSDbContext : DbContext

    {
        private readonly AppSettings _appSettings;
        public RMSDbContext(DbContextOptions<RMSDbContext> options, IOptions<AppSettings> appSettings) : base(options)
        {
            _appSettings = appSettings.Value;
        }

        public virtual DbSet<ApplicationUser>  ApplicationUsers { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        //public virtual DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_appSettings.DefaultConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoUrl)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IDUrl)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetAddress1)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(255);

                entity.Property(e => e.CitySuburbTown)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(15);

                // Define the relationship between ApplicationUser and Property
                entity.HasMany(u => u.Properties)
                    .WithOne(p => p.User)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                 entity.HasOne(e => e.Booking)
                .WithOne(b => b.User)
                .HasForeignKey<Booking>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                // Adjust the delete behavior as needed
            });




            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.CitySuburbTown)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("City_Suburb_Town");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateProvienceRegion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("State_Provience_Region");

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.ZipPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Zip_PostalCode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            //modelBuilder.Entity<Booking>(entity =>
            //{
            //    entity.HasKey(e => e.BookingId); // Set BookingId as the primary key
            //    entity.Property(e => e.BookingDate)
            //        .IsRequired();
            //    entity.HasOne(e => e.Property) // Define the relationship with Property
            //        .WithMany(p => p.Bookings) // One Property can have multiple Bookings
            //        .HasForeignKey(e => e.PropertyId) // Foreign key for PropertyId
            //        .OnDelete(DeleteBehavior.Restrict); // You can adjust the delete behavior as needed

            //    entity.HasOne(e => e.User) // Define the one-to-one relationship with ApplicationUser
            //        .WithOne(u => u.Booking) // One User can have only one Booking
            //        .HasForeignKey<Booking>(e => e.UserId) // Foreign key for UserId in Booking
            //        .OnDelete(DeleteBehavior.Restrict);
            //});


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

