using PrismWeatherApp.Core.Models;

namespace PrismWeatherApp.Core
{
    public static class TemperatureStatic
    {
        public static string CityName { get; set; }
        public static float Latitiude { get; set; }
        public static float Longitiude { get; set; }
        public static TemperatureHourly Hourly { get; set; }
    }
}
