using Bogus;
using System;
using WMS_backend.Models.DBModels;
using WMS_backend.Models.Enums;

namespace WMS_backend.Data
{
    public class DataGenerator
    {
        Faker<AppUser> userFake;
        Faker<Company> companyFake;
        Faker<Client> clientFake;
        Faker<Supplier> supplierFake;
        Faker<Location> locationFake;
        Faker<Product> productFake;
        Faker<ProductVariant> productVariantFake;


        List<Company> company;
        List<AppUser> user;
        List<Client> client;
        List<Supplier> supplier;
        List<Location> location;
        List<Platform> platform;
        List<Courier> courier;
        List<Product> product;
        List<ProductVariant> productVariant;
        List<CompanyPermission> companyPermission;
        List<UserPermission> userPermission;

        public DataGenerator()
        {
            Randomizer.Seed = new Random(123);
        }

        public List<Company> GenerateCompany()
        {
            var companyId = 100;
            companyFake = new Faker<Company>()
                .RuleFor(u => u.CompanyId, f => companyId++)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.IsArchived, f => false)
                .RuleFor(u => u.CreatedDateTime, f => f.Date.Recent().ToUniversalTime());
            company = companyFake.Generate(2);
            return company;
        }

        public List<AppUser> GenerateUser()
        {
            var userId = 100;
            userFake = new Faker<AppUser>()
                .RuleFor(u => u.Id, f => userId++)
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.CreatedDateTime, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(u => u.ModifiedDateTime, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(u => u.IsArchived, f => f.Random.Bool())
                .RuleFor(u => u.PasswordHash, f => "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==")
                .RuleFor(u => u.SecurityStamp, f => "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI")
                .RuleFor(u => u.CompanyId, f => f.PickRandom(company).CompanyId);
            user = userFake.Generate(10);
            foreach(var u in user)
            {
                u.UserName = u.Email;
                u.NormalizedEmail = u.Email.ToUpper();
                u.NormalizedUserName = u.Email.ToUpper();
            }
            return user;
        }
        public List<Client> GenerateClient()
        {
            var clientId = 100;
            clientFake = new Faker<Client>()
                .RuleFor(u => u.ClientId, f => clientId++)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Address1, f => f.Address.StreetAddress().OrNull(f))
                .RuleFor(u => u.Address2, f => f.Address.SecondaryAddress().OrNull(f))
                .RuleFor(u => u.State, f => f.Address.State().OrNull(f))
                .RuleFor(u => u.City, f => f.Address.City().OrNull(f))
                .RuleFor(u => u.Zip, f => f.Address.ZipCode().OrNull(f))
                .RuleFor(u => u.Note, f => f.Random.Words(10).OrNull(f))
                .RuleFor(u => u.CompanyId, f => f.PickRandom(company).CompanyId);
            client = clientFake.Generate(100);
            return client;
        }

        public List<Supplier> GenerateSupplier()
        {
            var id = 100;
            supplierFake = new Faker<Supplier>()
                .RuleFor(u => u.SupplierId, f => id++)
                .RuleFor(u => u.Name, f => f.Commerce.Department())
                .RuleFor(u => u.Address, f => f.Address.FullAddress().OrNull(f))
                .RuleFor(u => u.Contact, f => f.Name.FullName().OrNull(f))
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber().OrNull(f))
                .RuleFor(u => u.Email, f => f.Internet.Email().OrNull(f))
                .RuleFor(u => u.IsArchived, f => f.Random.Bool())
                .RuleFor(u => u.CompanyId, f => f.PickRandom(company).CompanyId);
            supplier = supplierFake.Generate(100);
            return supplier;
        }

        public List<Platform> GeneratePlatform()
        {
            platform =
            [
                new Platform { PlatformId = 100, Name = "Amazon" },
                new Platform { PlatformId = 101, Name = "Ebay" }
            ];
            return platform;
        }

        public List<Courier> GenerateCourier()
        {
            courier =
            [
                new Courier { CourierId = 100, Name = "Amazon" },
                new Courier { CourierId = 101, Name = "USPS" }
            ];
            return courier;
        }

        public List<Location> GenerateLocation()
        {
            var id = 100;
            locationFake = new Faker<Location>()
                .RuleFor(u => u.LocationId, f => id++)
                .RuleFor(u => u.Name, f => f.Commerce.Department())
                .RuleFor(u => u.Address, f => f.Address.FullAddress().OrNull(f))
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber().OrNull(f))
                .RuleFor(u => u.LocationType, f => f.PickRandom<EnumLocationType>())
                .RuleFor(u => u.IsArchived, f => f.Random.Bool())
                .RuleFor(u => u.CompanyId, f => f.PickRandom(company).CompanyId);
            location = locationFake.Generate(100);
            return location;
        }

        public List<Product> GenerateProduct()
        {
            productFake = new Faker<Product>()
                .RuleFor(u => u.ProductId, f => f.Random.Guid())
                .RuleFor(u => u.Name, f => f.Commerce.ProductName())
                .RuleFor(u => u.Description, f => f.Commerce.ProductDescription().OrNull(f))
                .RuleFor(u => u.SupplierId, f => f.PickRandom(supplier).SupplierId.OrNull(f))
                .RuleFor(u => u.IsArchived, f => f.Random.Bool())
                .RuleFor(u => u.CompanyId, f => f.PickRandom(company).CompanyId);
            product = productFake.Generate(100);
            return product;
        }

        public List<ProductVariant> GenerateProductVariant()
        {
            productVariantFake = new Faker<ProductVariant>()
                .RuleFor(u => u.ProductVariantId, f => f.Random.Guid())
                .RuleFor(u => u.SKU, f => f.Random.Word())
                .RuleFor(u => u.Barcode, f => f.Random.Word())
                .RuleFor(u => u.Barcode1, f => f.Random.Word().OrNull(f))
                .RuleFor(u => u.Barcode2, f => f.Random.Word().OrNull(f))
                .RuleFor(u => u.Barcode3, f => f.Random.Word().OrNull(f))
                .RuleFor(u => u.Width, f => f.Random.Double().OrNull(f))
                .RuleFor(u => u.Length, f => f.Random.Double().OrNull(f))
                .RuleFor(u => u.Height, f => f.Random.Double().OrNull(f))
                .RuleFor(u => u.Weight, f => f.Random.Double().OrNull(f))
                .RuleFor(u => u.PurchasePrice, f => f.Random.Float().OrNull(f))
                .RuleFor(u => u.RetailPrice, f => f.Random.Float().OrNull(f))
                .RuleFor(u => u.TaxRate, f => f.Random.Float(0, (float)0.1).OrNull(f))
                .RuleFor(u => u.IsArchived, f => f.Random.Bool())
                .RuleFor(u => u.ProductId, f => f.PickRandom(product).ProductId);
            productVariant = productVariantFake.Generate(200);
            return productVariant;
        }

        public List<CompanyPermission> GenerateCompanyPermission()
        {
            companyPermission = new List<CompanyPermission>();
            var id = 100;
            for (var idx = 0; idx < company.Count; idx++)
            {
                var c = company[idx];
                foreach (EnumPermissionType item in Enum.GetValues(typeof(EnumPermissionType)))
                {
                    var temp = new CompanyPermission { CompanyPermissionId = id++, CompanyId = c.CompanyId, PermissionType = item };
                    companyPermission.Add(temp);

                }
            }
            return companyPermission;
        }

        public List<UserPermission> GenerateUserPermission()
        {
            userPermission = new List<UserPermission>();
            var id = 100;
            for (var idx = 0; idx < user.Count; idx++)
            {
                var c = user[idx];
                foreach (EnumPermissionType ep in Enum.GetValues(typeof(EnumPermissionType)))
                {
                    userPermission.Add(new UserPermission { UserPermissionId = id++, UserId = c.Id, IsCrud = true, PermissionType = ep });
                }

            }
            return userPermission;
        }


    }
}
