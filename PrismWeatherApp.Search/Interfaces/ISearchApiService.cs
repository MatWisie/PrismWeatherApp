using PrismWeatherApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismWeatherApp.Search.Interfaces
{
    public interface ISearchApiService
    {
        Task<CitiesResult> GetCities(string city);
    }
}