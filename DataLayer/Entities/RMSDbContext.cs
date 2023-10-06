//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataLayer.Entities
//{
//    public partial class RMSDbContext : DbContext

//    {
//        //public RMSDbContext()
//        //{
//        //}
//        public RMSDbContext(DbContextOptions<RMSDbContext> options) : base(options)
//        {
//        }

//        public virtual DbSet<User> Users { get; set; }
//        public virtual DbSet<Property> Properties { get; set; }
//        public virtual DbSet<Booking> Bookings { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("data source=LENOVO-Y700\\MSSQL2022;initial catalog=RMSDb;persist security info=True;User Id=sa;Password=abc123#;MultipleActiveResultSets=True;App=EntityFramework;");
//            }
//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Property>(entity =>
//            {
//                entity.ToTable("Property");

//                entity.Property(e => e.CitySuburbTown)
//                    .HasMaxLength(255)
//                    .IsUnicode(false)
//                    .HasColumnName("City_Suburb_Town");

//                entity.Property(e => e.Country)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.PropertyName)
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.Property(e => e.PropertyType)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.StateProvienceRegion)
//                    .HasMaxLength(255)
//                    .IsUnicode(false)
//                    .HasColumnName("State_Provience_Region");

//                entity.Property(e => e.StreetAddress)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.StreetAddress2)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.UserId).HasMaxLength(450);

//                entity.Property(e => e.ZipPostalCode)
//                    .HasMaxLength(10)
//                    .IsUnicode(false)
//                    .HasColumnName("Zip_PostalCode");

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.Properties)
//                    .HasForeignKey(d => d.UserId)
//                    .HasConstraintName("Property_AspNetUsers_UserIdFK");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }
//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}

