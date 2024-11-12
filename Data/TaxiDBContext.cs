using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Taxi_Backend.Models;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.Enums;
using Taxi_Backend.Services;

namespace Taxi_Backend.Data
{
    public class TaxiDBContext : IdentityDbContext<AppUser, AppRole, long, IdentityUserClaim<long>, AppUserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        private readonly DataGenerator dataGenerator;

        public TaxiDBContext(DbContextOptions options, DataGenerator dataGenerator) : base(options)
        {
            this.dataGenerator = dataGenerator;
        }
        public virtual DbSet<BackgroundHistory> BackgroundHistory { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerQueue> CustomerQueue { get; set; }
        public virtual DbSet<DriverQueue> DriverQueue { get; set; }
        public virtual DbSet<Taxi> Taxi { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }


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
            modelBuilder.Entity<AppRole>().HasData(
              Enum.GetValues(typeof(EnumUserRole))
                  .Cast<EnumUserRole>()
                  .Select(e => new AppRole()
                  {
                      Id = (long)e,
                      Name = e.ToString()
                  })
            );

            modelBuilder.Entity<AppUser>(a =>
            {
                a.HasIndex(x => x.CompanyId);
                a.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });
            modelBuilder.Entity<AppUserRole>(a =>
            {

            });
            modelBuilder.Entity<AppRole>(a =>
            {
                a.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            });
            modelBuilder.Entity<BackgroundHistory>(a =>
            {

            });

            modelBuilder.Entity<Company>(a =>
            {

            });
            modelBuilder.Entity<Customer>(a =>
            {
                a.HasIndex(x => x.PhoneNumber)
                .HasFilter("PhoneNumber is not null")
                .IsUnique();
            });

            modelBuilder.Entity<CustomerQueue>(a =>
            {
                a.HasIndex(x => x.CreatedDateTime)
                .IsDescending();
                a.HasIndex(x => x.CustomerId)
                .HasFilter("CustomerId is not null")
                .IsUnique();
                a.HasIndex(x => x.CompanyId);
                a.HasIndex(x => x.QueueStatus);
                a.HasIndex(x => x.TripId);
            });

            modelBuilder.Entity<DriverQueue>(a =>
            {
                a.HasIndex(x => x.CreatedDateTime)
                .IsDescending();
                a.HasIndex(x => x.DriverId)
                .HasFilter("DriverId is not null")
                .IsUnique();
                a.HasIndex(x => x.QueueStatus);
                a.HasIndex(x => x.TripId);
            });
            modelBuilder.Entity<Taxi>(a =>
            {
                a.HasIndex(x => x.DriverId).IsUnique();
                a.HasIndex(x => x.Size);
            });

            modelBuilder.Entity<Trip>(a =>
            {
                a.HasIndex(x => x.TripStatus);
                a.HasIndex(x => x.DriverId);
                a.HasIndex(x => x.CustomerId);
                a.HasIndex(x => x.CompanyId);
                a.HasIndex(x => x.CompletedTime);
            });

            modelBuilder.Entity<Company>().HasData(dataGenerator.GenerateCompany());
            modelBuilder.Entity<AppUser>().HasData(dataGenerator.GenerateUser());
            modelBuilder.Entity<AppUserRole>().HasData(dataGenerator.GenerateUserRole());
            modelBuilder.Entity<Customer>().HasData(dataGenerator.GenerateCustomer());
            //modelBuilder.Entity<Supplier>().HasData(dataGenerator.GenerateSupplier());
            //modelBuilder.Entity<Location>().HasData(dataGenerator.GenerateLocation());
            //modelBuilder.Entity<Platform>().HasData(dataGenerator.GeneratePlatform());
            //modelBuilder.Entity<Courier>().HasData(dataGenerator.GenerateCourier());
            //modelBuilder.Entity<Product>().HasData(dataGenerator.GenerateProduct());
            //modelBuilder.Entity<ProductVariant>().HasData(dataGenerator.GenerateProductVariant());
            //modelBuilder.Entity<CompanyPermission>().HasData(dataGenerator.GenerateCompanyPermission());
            //modelBuilder.Entity<UserPermission>().HasData(dataGenerator.GenerateUserPermission());
        }
    }


}
