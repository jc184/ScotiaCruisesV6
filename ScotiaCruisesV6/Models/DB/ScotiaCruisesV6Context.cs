using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScotiaCruisesV6.Models.DB
{
    public partial class ScotiaCruisesV6Context : DbContext
    {
        public ScotiaCruisesV6Context()
        {
        }

        public ScotiaCruisesV6Context(DbContextOptions<ScotiaCruisesV6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK_dbo.BookingId");

                entity.Property(e => e.SailingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Bookings_dbo.Customers_CustomerId");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK_dbo.Bookings_dbo.Routes_RouteId");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_dbo.Customers");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PK_dbo.Routes");

                entity.Property(e => e.RouteName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
