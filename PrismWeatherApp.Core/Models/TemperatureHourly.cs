namespace PrismWeatherApp.Core.Models
{
    public class TemperatureHourlyRaw
    {
        public List<DateTime> time { get; set; }
        public List<double> temperature_2m { get; set; }
    }
}
