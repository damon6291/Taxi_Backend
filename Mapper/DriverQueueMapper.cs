using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

namespace Taxi_Backend.Mapper
{
    public static class DriverQueueMapper
    {
        public static DriverQueueDTO DriverQueueToDTO(DriverQueue queue)
        {
            return new DriverQueueDTO()
            {
                DriverQueueId = queue.DriverQueueId,
                DriverId = queue.DriverId,
                TripId = queue.TripId,
                CompanyId = queue.CompanyId,
                EnumQueueStatus = queue.QueueStatus,
                QueueStatus = queue.QueueStatus.ToString(),
                Latitude = queue.Latitude,
                Longitude = queue.Longitude,
                DriverName = queue.Driver?.Name,
                DriverPhoneNumber = queue.Driver?.PhoneNumber,
                DriverNumber = queue.Driver?.DriverNumber,
                TripPickupAddress = queue.Trip?.PickupAddress
            };
        }

        public static DriverQueue DTOToDriverQueue(DriverQueueDTO dto)
        {
            return new DriverQueue()
            {
                DriverQueueId = dto.DriverQueueId,
                DriverId = dto.DriverId,
                TripId = dto.TripId,
                CompanyId = dto.CompanyId,
                QueueStatus = dto.EnumQueueStatus,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };
        }
    }
} 