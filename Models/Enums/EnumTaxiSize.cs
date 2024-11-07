using System.ComponentModel;

namespace Taxi_Backend.Models.Enums
{
    public enum EnumTaxiSize
    {
        [Description("1 - 4 people")]
        SMALL = 1,
        [Description("4 + people")]
        LARGE = 2,
    }
}
