using Taxi_Backend.Data;

using Taxi_Backend.Models;

using Taxi_Backend.Models.DBModels;

using Microsoft.EntityFrameworkCore;



namespace Taxi_Backend.Managers

{

    public class CompanyManager

    {

        private readonly TaxiDBContext ctx;



        public CompanyManager(TaxiDBContext ctx)

        {

            this.ctx = ctx;

        }



        public async Task<(bool success, object response)> CreateCompany(Company company)

        {

            try

            {
                await ctx.Company.AddAsync(company);
                await ctx.SaveChangesAsync();
                return (true, company);
            }

            catch (Exception ex)

            {

                return (false, $"Error creating company: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> UpdateCompany(Company company)

        {

            try

            {

                var existingCompany = await ctx.Company.FindAsync(company.CompanyId);

                if (existingCompany == null)

                    return (false, "Company not found");



                existingCompany.Name = company.Name;

                existingCompany.Address = company.Address;

                existingCompany.Contact = company.Contact;

                existingCompany.PhoneNumber = company.PhoneNumber;

                existingCompany.Email = company.Email;

                existingCompany.TimeZone = company.TimeZone;

                existingCompany.IsArchived = company.IsArchived;



                ctx.Company.Update(existingCompany);

                await ctx.SaveChangesAsync();

                return (true, existingCompany);

            }

            catch (Exception ex)

            {

                return (false, $"Error updating company: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> DeleteCompany(long companyId)

        {

            try

            {

                var company = await ctx.Company.FindAsync(companyId);

                if (company == null)

                    return (false, "Company not found");



                company.IsArchived = true;

                await ctx.SaveChangesAsync();

                return (true, "Company archived successfully");

            }

            catch (Exception ex)

            {

                return (false, $"Error deleting company: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> GetCompanyById(long companyId)

        {

            try

            {

                var company = await ctx.Company

                    .Include(c => c.Users)

                    .FirstOrDefaultAsync(c => c.CompanyId == companyId && !c.IsArchived);



                if (company == null)

                    return (false, "Company not found");



                return (true, company);

            }

            catch (Exception ex)

            {

                return (false, $"Error retrieving company: {ex.Message}");

            }

        }


        public IQueryable<Company> GetCompanyByUserID(long userId)

        {

            var company = ctx.Users.Include(x => x.Company).Where(x => x.Id == userId).Select(x => x.Company);

            return company;

        }

        public async Task<(int count, List<Company> items)> GetCompanies(Page page)
        {
            try
            {
                var activeRecords = ctx.Company.Where(x => !x.IsArchived);
                return await page.Get(activeRecords);
            }
            catch (Exception ex)
            {
                return (0, new List<Company>());
            }
        }

    }

}


