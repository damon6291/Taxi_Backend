using System.Globalization;

namespace Taxi_Backend
{
    public static class Constants
    {
        public static double TRIP_MATCH_MILE_RANGE = 5;
        public static int DRIVER_MATCH_IDLE_TIME = 2; // Driver needs to wait atleast 2 seconds to be matched / re matched.


        /// <summary>
        /// Driver = when trip matched from background service
        /// Customer = when driver accepted the ride.
        /// </summary>
        public static string MATCH = "match";
        /// <summary>
        /// Customer = get driver location update
        /// </summary>
        public static string UPDATEDRIVERLOCATION = "updatedriverlocation";
        /// <summary>
        /// Customer = get notified that the trip started
        /// </summary>
        public static string TRIPSTART = "tripstart";
        /// <summary>
        /// Customer = get notified that the trip completed
        /// </summary>
        public static string TRIPCOMPLETE = "tripcomplete";
        /// <summary>
        /// Driver = get notified when customer canceled trip
        /// </summary>
        public static string CUSTOMERCANCEL = "customercancel";
        /// <summary>
        /// Customer = get notified when customer canceled trip
        /// </summary>
        public static string DRIVERCANCEL = "drivercancel";

        public static string COMPANYCANCEL = "companycancel";
        public static string PRICEUPDATE = "priceupdate";
        public static string NOTEUPDATE = "noteupdate";
        public static string COMPANYTRIP = "companytrip";
        public static string ALCOHOLDRIVERMATCH = "alcoholdrivermatch";

        public static CultureInfo USCULTURE = new CultureInfo("en-us");

    }
}
