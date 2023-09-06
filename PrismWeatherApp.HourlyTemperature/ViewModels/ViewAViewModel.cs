using Prism.Commands;
using Prism.Mvvm;
using PrismWeatherApp.Core;
using PrismWeatherApp.Core.Interfaces;
using PrismWeatherApp.Core.Models;
using System.Collections.ObjectModel;

namespace PrismWeatherApp.HourlyTemperature.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IAppCommands _appCommands;
        public ViewAViewModel(IAppCommands appCommands)
        {
            _appCommands = appCommands;
            ReloadHourlyTemp();
            ReloadHourlyTempCommand = new DelegateCommand(ReloadHourlyTemp);
            _appCommands.GlobalSearchCommand.RegisterCommand(ReloadHourlyTempCommand);

        }

        private string cityName;
        public string CityName
        {
            get
            {
                return cityName;
            }
            set
            {
                SetProperty(ref cityName, value);
            }
        }
        public ObservableCollection<TemperatureHourlyConnect> Hourly { get; set; }

        public DelegateCommand ReloadHourlyTempCommand { get; private set; }
        private void ReloadHourlyTemp()
        {
            CityName = TemperatureStatic.CityName;
            Hourly = TemperatureStatic.Hourly;
        }

    }
}
