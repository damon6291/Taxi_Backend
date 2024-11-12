using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

namespace Taxi_Backend.Mapper
{
    public static class CustomerMapper
    {
        public static CustomerDTO CustomerToDTO(Customer customer)
        {
            return new CustomerDTO()
            {
                CustomerId = customer.CustomerId,
                PhoneNumber = customer.PhoneNumber,
            };
        }

        public static Customer DTOToCustomer(CustomerDTO dto)
        {
            return new Customer()
            {
                CustomerId = dto.CustomerId,
                PhoneNumber = dto.PhoneNumber,
            };
        }
    }
} 