using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

namespace Taxi_Backend.Mapper
{
    public static class TaxiMapper
    {
        public static TaxiDTO TaxiToDTO(Taxi taxi)
        {
            return new TaxiDTO()
            {
                TaxiId = taxi.TaxiId,
                DriverId = taxi.DriverId,
                LicensePlate = taxi.LicensePlate,
                Model = taxi.Model,
                Color = taxi.Color.ToString(),
                EnumColor = taxi.Color,
                EnumSize = taxi.Size,
                EnumMake = taxi.Make,
                Size = taxi.Size.ToString(),
                Make = taxi.Make.ToString()
            };
        }

        public static Taxi DTOToTaxi(TaxiDTO dto)
        {
            return new Taxi()
            {
                TaxiId = dto.TaxiId,
                DriverId = dto.DriverId,
                LicensePlate = dto.LicensePlate,
                Model = dto.Model,
                Color = dto.EnumColor,
                Size = dto.EnumSize,
                Make = dto.EnumMake
            };
        }
    }
} 