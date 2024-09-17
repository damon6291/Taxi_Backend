using Bogus;
using WMS_backend.Models.DBModels;

namespace WMS_backend.Data
{
    public class DataGenerator
    {
        Faker<AppUser> userFake;
        Faker<Company> companyFake;
        List<Company> company;
        public DataGenerator()
        {
            Randomizer.Seed = new Random(123);
        }

        public List<Company> GenerateCompany()
        {
            var companyId = 10000;
            companyFake = new Faker<Company>()
                .RuleFor(u => u.CompanyId, f => companyId++)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.IsArchived, f => false)
                .RuleFor(u => u.CreatedDateTime, f => f.Date.Recent().ToUniversalTime());

            company = companyFake.Generate(5);

            return company;
        }

        public List<AppUser> GenerateUser()
        {
            var userId = 10000;
            userFake = new Faker<AppUser>()
                .RuleFor(u => u.Id, f => userId++)
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.CreatedDateTime, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(u => u.ModifiedDateTime, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(u => u.CompanyId, f => f.PickRandom(company).CompanyId);
            return userFake.Generate(100);
        }
    }
}
