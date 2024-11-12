using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

namespace Taxi_Backend.Mapper
{
    public static class CustomerQueueMapper
    {
        public static CustomerQueueDTO CustomerQueueToDTO(CustomerQueue queue)
        {
            return new CustomerQueueDTO()
            {
                CustomerQueueId = queue.CustomerQueueId,
                CustomerId = queue.CustomerId,
                TripId = queue.TripId,
                CompanyId = queue.CompanyId,
                EnumQueueStatus = queue.QueueStatus,
                QueueStatus = queue.QueueStatus.ToString(),
                CreatedDateTime = queue.CreatedDateTime,
                CustomerPhoneNumber = queue.Customer.PhoneNumber,
                TripPickupAddress = queue.Trip.PickupAddress,
                EnumCalledTaxiSize = queue.Trip.CalledTaxiSize,
                CalledTaxiSize = queue.Trip.CalledTaxiSize.ToString()
            };
        }

        public static CustomerQueue DTOToCustomerQueue(CustomerQueueDTO dto)
        {
            return new CustomerQueue()
            {
                CustomerQueueId = dto.CustomerQueueId,
                CustomerId = dto.CustomerId,
                TripId = dto.TripId,
                CompanyId = dto.CompanyId,
                QueueStatus = dto.EnumQueueStatus,
                CreatedDateTime = dto.CreatedDateTime
            };
        }
    }
} 