using PrismWeatherApp.Core.Models;

namespace PrismWeatherApp.Core.Interfaces
{
    public interface ISearchApiService
    {
        Task<CitiesResult> GetCities(string city);
        Task<Temperature> GetTemperature(float latitiude, float longitiude);
    }
}