using Newtonsoft.Json;
using PrismWeatherApp.Core.Interfaces;
using PrismWeatherApp.Core.Models;

namespace PrismWeatherApp.Core
{
    public class SearchApiService : ISearchApiService
    {
        public async Task<CitiesResult> GetCities(string city)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    if (city == String.Empty || city == null || city.Length < 3)
                    {
                        throw new ArgumentNullException();
                    }
                    var response = await httpClient.GetAsync($"https://geocoding-api.open-meteo.com/v1/search?name={city}&count=3&language=en&format=json").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    string jsonContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<CitiesResult>(jsonContent);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured: {ex.Message}");
                    return null;
                }
            }
        }
        public async Task<Temperature> GetTemperature(float latitiude, float longitiude)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string latitiudeString = latitiude.ToString().Replace(",", ".");
                    string longitiudeString = longitiude.ToString().Replace(",", ".");

                    var response = await httpClient.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitiudeString}&longitude={longitiudeString}&hourly=temperature_2m").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    string jsonContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<Temperature>(jsonContent);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
