using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

namespace Taxi_Backend.Mapper
{
    public static class CompanyMapper
    {
        public static CompanyDTO CompanyToDTO(Company company)
        {
            return new CompanyDTO()
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                Contact = company.Contact
            };
        }

        public static Company DTOToCompany(CompanyDTO dto)
        {
            return new Company()
            {
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Contact = dto.Contact
            };
        }
    }
} 