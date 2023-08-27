namespace PrismWeatherApp.Core.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string feature_code { get; set; }
        public string country_code { get; set; }
        public string country { get; set; }
        public string displayPath
        {
            get
            {
                return name + ", " + country;
            }
        }
    }
}
