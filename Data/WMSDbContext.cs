using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using WMS_backend.Models.DBModels;
using WMS_backend.Models.Enums;
using WMS_backend.Services;

namespace WMS_backend.Data
{
    public class WMSDbContext : IdentityDbContext<AppUser, IdentityRole<long>, long>
    {
        private readonly DataGenerator dataGenerator;

        public WMSDbContext(DbContextOptions options, DataGenerator dataGenerator) : base(options)
        {
            this.dataGenerator = dataGenerator;
        }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyCourier> CompanyCourier { get; set; }
        public virtual DbSet<CompanyPermission> CompanyPermission { get; set; }
        public virtual DbSet<CompanyPlatform> CompanyPlatform { get; set; }
        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<PermissionType> PermissionType { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }
        public virtual DbSet<Platform> PlatformCourier { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBundle> ProductBundle { get; set; }
        public virtual DbSet<ProductHistory> ProductHistory { get; set; }
        public virtual DbSet<ProductVariant> ProductVariant { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderHistory> PurchaseOrderHistory { get; set; }
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }
        public virtual DbSet<PurchaseRequest> PurchaseRequest { get; set; }
        public virtual DbSet<Rack> Rack { get; set; }
        public virtual DbSet<ShippingOption> ShippingOption { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        public virtual DbSet<UserPreference> UserPreference { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");
            foreach (var p in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.GetMaxLength() == null))
            {
                p.SetMaxLength(255);
            }
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.ClrType.GetProperties().Where(p => p.PropertyType == typeof(Guid) && p.CustomAttributes.Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute))))
                {
                    modelBuilder
                        .Entity(entity.ClrType)
                        .Property(property.Name)
                        .HasDefaultValueSql("uuid_generate_v4()");
                }
            }
            modelBuilder.Entity<PermissionType>().HasData(
              Enum.GetValues(typeof(EnumPermissionType))
                  .Cast<EnumPermissionType>()
                  .Select(e => new PermissionType()
                  {
                      PermissionTypeId = e,
                      Name = e.ToString()
                  })
            );

            modelBuilder.Entity<AppUser>(a =>
            {

            });
            modelBuilder.Entity<Company>(a =>
            {
               
            });
            modelBuilder.Entity<CompanyCourier>(a =>
            {

            });
            modelBuilder.Entity<CompanyPermission>(a =>
            {

            });
            modelBuilder.Entity<CompanyPlatform>(a =>
            {

            });
            modelBuilder.Entity<Courier>(a =>
            {

            });
            modelBuilder.Entity<Inventory>(a =>
            {

            });
            modelBuilder.Entity<Location>(a =>
            {

            });
            modelBuilder.Entity<Notification>(a =>
            {

            });
            modelBuilder.Entity<Order>(a =>
            {

            });
            modelBuilder.Entity<OrderHistory>(a =>
            {

            });
            modelBuilder.Entity<OrderItem>(a =>
            {

            });
            modelBuilder.Entity<Platform>(a =>
            {

            });
            modelBuilder.Entity<PlatformCourier>(a =>
            {

            });
            modelBuilder.Entity<Product>(a =>
            {

            });
            modelBuilder.Entity<ProductBundle>(a =>
            {

            });
            modelBuilder.Entity<ProductHistory>(a =>
            {

            });
            modelBuilder.Entity<ProductVariant>(a =>
            {

            });
            modelBuilder.Entity<PurchaseOrder>(a =>
            {

            });
            modelBuilder.Entity<PurchaseOrderHistory>(a =>
            {

            });
            modelBuilder.Entity<PurchaseOrderItem>(a =>
            {

            });
            modelBuilder.Entity<PurchaseRequest>(a =>
            {

            });
            modelBuilder.Entity<Rack>(a =>
            {

            });
            modelBuilder.Entity<ShippingOption>(a =>
            {

            });
            modelBuilder.Entity<Supplier>(a =>
            {

            });
            modelBuilder.Entity<Tote>(a =>
            {

            });
            modelBuilder.Entity<UserPermission>(a =>
            {

            });
            modelBuilder.Entity<UserPreference>(a =>
            {

            });

            modelBuilder.Entity<Company>().HasData(dataGenerator.GenerateCompany());
            modelBuilder.Entity<AppUser>().HasData(dataGenerator.GenerateUser());
            modelBuilder.Entity<Client>().HasData(dataGenerator.GenerateClient());
            modelBuilder.Entity<Supplier>().HasData(dataGenerator.GenerateSupplier());
            modelBuilder.Entity<Location>().HasData(dataGenerator.GenerateLocation());
            modelBuilder.Entity<Platform>().HasData(dataGenerator.GeneratePlatform());
            modelBuilder.Entity<Courier>().HasData(dataGenerator.GenerateCourier());
            modelBuilder.Entity<Product>().HasData(dataGenerator.GenerateProduct());
            modelBuilder.Entity<ProductVariant>().HasData(dataGenerator.GenerateProductVariant());
            modelBuilder.Entity<CompanyPermission>().HasData(dataGenerator.GenerateCompanyPermission());
            modelBuilder.Entity<UserPermission>().HasData(dataGenerator.GenerateUserPermission());
        }
    }


}
