using Microsoft.EntityFrameworkCore;
using Shipping.Infra.Models;

namespace Shipping.Data
{
    public class ShippingContext: DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Service> Services { get; set; }

        public ShippingContext(DbContextOptions<ShippingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Shipment>(e =>
            {
                e
                .ToTable("shipment")
                .HasKey(k => k.Id);

                e
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

                e.HasOne(k => k.Service)
                .WithMany(k => k.Shipments)
                .HasForeignKey(k => k.ServiceId)
                .HasConstraintName("FK_Shipments_Services");

            });

            modelBuilder.Entity<ServiceProvider>(e =>
            {
                e.ToTable("serviceProvider").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<Service>(e =>
            {
                e.ToTable("service").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.HasOne(k => k.ServiceProvider)
               .WithMany(k => k.Services)
               .HasForeignKey(k => k.ProviderId)
               .HasConstraintName("FK_Services_ServiceProviders");

            });
        }
    }
}