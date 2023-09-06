using Prism.Mvvm;
using PrismWeatherApp.Core;
using PrismWeatherApp.Core.Interfaces;
using PrismWeatherApp.Core.Models;

namespace PrismWeatherApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ISearchApiService _searchApiService { get; }
        public MainWindowViewModel(ISearchApiService searchApiService)
        {
            _searchApiService = searchApiService;

            //TODO: find cleaner way to load city
            City currentCity = JsonServices.LoadJson<City>("currentLoc.json");
            CityStatic.country = currentCity.country;
            CityStatic.name = currentCity.name;
            CityStatic.latitude = currentCity.latitude;
            CityStatic.longitude = currentCity.longitude;
            CityStatic.feature_code = currentCity.feature_code;
            CityStatic.country_code = currentCity.country_code;
            CityStatic.id = currentCity.id;

            var tmpTemperature = _searchApiService.GetTemperature(CityStatic.latitude, CityStatic.longitude).Result;
            TemperatureStatic.CityName = CityStatic.name;
            TemperatureStatic.Latitiude = tmpTemperature.latitude;
            TemperatureStatic.Longitiude = tmpTemperature.longitude;
            TemperatureStatic.Hourly = tmpTemperature.hourly;
        }

    }
}
