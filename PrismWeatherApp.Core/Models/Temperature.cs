namespace PrismWeatherApp.Core.Models
{
    public class Temperature
    {
        public double Latitiude { get; set; }
        public double Longitiude { get; set; }
        public TemperatureHourly Hourly { get; set; }
    }
}
