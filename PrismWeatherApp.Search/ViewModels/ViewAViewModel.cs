using Prism.Mvvm;
using PrismWeatherApp.Core.Models;
using PrismWeatherApp.Search.Interfaces;
using System.Collections.ObjectModel;

namespace PrismWeatherApp.Search.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly ISearchApiService _searchApiService;
        private IAppCommands _appCommands;
        public IAppCommands AppCommands
        {
            get { return _appCommands; }
            set { SetProperty(ref _appCommands, value); }
        }

        public ViewAViewModel(ISearchApiService searchApiService, IAppCommands appCommands)
        {
            _searchApiService = searchApiService;
            AppCommands = appCommands;
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

        private bool cityDropDownOpen;

        public bool CityDropDownOpen
        {
            get { return cityDropDownOpen; ; }
            set
            {
                SetProperty(ref cityDropDownOpen, value);
            }
        }



    }
}
