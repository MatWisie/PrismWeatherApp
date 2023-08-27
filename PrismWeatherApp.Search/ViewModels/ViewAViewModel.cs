using Prism.Mvvm;
using PrismWeatherApp.Core.Models;
using PrismWeatherApp.Search.Interfaces;
using System.Collections.ObjectModel;

namespace PrismWeatherApp.Search.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly ISearchApiService _searchApiService;
        public ViewAViewModel(ISearchApiService searchApiService)
        {
            _searchApiService = searchApiService;
        }

        public ObservableCollection<City> Cities
        {
            get
            {
                var tmpCities = _searchApiService.GetCities(CityText).Result;
                if (tmpCities == null || tmpCities.Results == null || tmpCities.Results.Count == 0)
                {
                    return new ObservableCollection<City>();
                }
                CityDropDownOpen = true;
                return new ObservableCollection<City>(tmpCities.Results);
            }
        }

        private string cityText;
        public string CityText
        {
            get
            {
                return cityText;
            }
            set
            {
                SetProperty(ref cityText, value);
                RaisePropertyChanged(nameof(Cities));

            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; }
        }

    }
}
