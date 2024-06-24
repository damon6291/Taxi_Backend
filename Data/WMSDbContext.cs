using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using WMS_backend.Models.DBModels;
using WMS_backend.Models.Enums;
using WMS_backend.Services;

namespace WMS_backend.Data
{
    public class WMSDbContext : DbContext
    {
        public WMSDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyPermission> CompanyPermission { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<PermissionType> PermissionType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }
        public virtual DbSet<PurchaseRequest> PurchaseRequest { get; set; }
        public virtual DbSet<Rack> Rack { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamLocation> TeamLocation { get; set; }
        public virtual DbSet<TeamUser> TeamUser { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        public virtual DbSet<UserPreference> UserPreference { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Company>(a =>
            {
               
            });
            modelBuilder.Entity<CompanyPermission>(a =>
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
            modelBuilder.Entity<Product>(a =>
            {

            });
            modelBuilder.Entity<PurchaseOrder>(a =>
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
            modelBuilder.Entity<Supplier>(a =>
            {

            });
            modelBuilder.Entity<Team>(a =>
            {

            });
            modelBuilder.Entity<TeamLocation>(a =>
            {

            });
            modelBuilder.Entity<TeamUser>(a =>
            {

            });
            modelBuilder.Entity<User>(a =>
            {

            });
            modelBuilder.Entity<UserPermission>(a =>
            {

            });
            modelBuilder.Entity<UserPreference>(a =>
            {

            });
        }
    }


}
