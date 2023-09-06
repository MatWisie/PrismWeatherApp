namespace PrismWeatherApp.Core.Models
{
    public class Temperature
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public TemperatureHourly hourly { get; set; }
    }
}
