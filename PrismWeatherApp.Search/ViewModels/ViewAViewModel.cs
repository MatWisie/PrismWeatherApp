using Prism.Commands;
using Prism.Mvvm;
using PrismWeatherApp.Core;
using PrismWeatherApp.Core.Interfaces;
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
            SearchCommand = new DelegateCommand(Search);
            _appCommands.GlobalSearchCommand.RegisterCommand(SearchCommand);
        }

        #region commands
        public DelegateCommand SearchCommand { get; private set; }
        private void Search()
        {
            if (SelectedCity != null)
            {
                var tmpTemperature = _searchApiService.GetTemperature(SelectedCity.latitude, SelectedCity.longitude).Result;
                TemperatureStatic.CityName = SelectedCity.name;
                TemperatureStatic.Latitiude = tmpTemperature.Latitiude;
                TemperatureStatic.Longitiude = tmpTemperature.Longitiude;
                TemperatureStatic.Hourly = tmpTemperature.Hourly;

            }
        }

        #endregion

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
