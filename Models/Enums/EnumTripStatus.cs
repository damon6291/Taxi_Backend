namespace Taxi_Backend.Models.Enums
{

    public enum EnumTripStatus
    {
        CREATED = 1,
        QUEUE = 2,
        MATCHING = 3,
        MATCHED = 4,
        COMPLETED = 6,
        DRIVERCANCELED = 7,
        CUSTOMERCANCELED = 8,
        COMPANYCANCELED = 9
    }
}
