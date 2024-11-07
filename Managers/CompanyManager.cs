using Taxi_Backend.Data;
using Taxi_Backend.Models;
using Taxi_Backend.Services;
using Microsoft.EntityFrameworkCore;
using Taxi_Backend.Models.DBModels;

namespace Taxi_Backend.Managers
{
    public class CompanyManager
    {

        private readonly TaxiDBContext ctx;


        public CompanyManager(TaxiDBContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<Company> GetCompanyByUserID(long userId)
        {
            var company = ctx.Users.Include(x => x.Company).Where(x => x.Id == userId).Select(x => x.Company);
            return company;
        }

        //public async Task<Company> CompanyReturn(long companyID, long userID)
        //{
        //    var companyUser = await ctx.CompanyUsers.Include(x => x.Company).ThenInclude(x => x.Drivers).ThenInclude(x => x.Taxi).Include(x => x.LoginUser).Where(x => x.CompanyID == companyID && x.LoginUserID == userID).FirstOrDefaultAsync();
        //    var ret = new CompanyReturn(companyUser);

        //    //foreach (var driver in company.Drivers)
        //    //{
        //    //    ret.Drivers.Add(new DriverReturn(driver));
        //    //}

        //    return ret;
        //}



    }
}
