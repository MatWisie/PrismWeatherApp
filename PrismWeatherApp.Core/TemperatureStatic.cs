using PrismWeatherApp.Core.Models;
using System.Collections.ObjectModel;

namespace PrismWeatherApp.Core
{
    public static class TemperatureStatic
    {
        public static string CityName { get; set; }
        public static float Latitiude { get; set; }
        public static float Longitiude { get; set; }
        public static ObservableCollection<TemperatureHourlyConnect> Hourly { get; set; } = new ObservableCollection<TemperatureHourlyConnect>();
    }
}
