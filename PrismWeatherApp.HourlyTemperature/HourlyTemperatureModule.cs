using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWeatherApp.Core;
using PrismWeatherApp.HourlyTemperature.Views;

namespace PrismWeatherApp.HourlyTemperature
{
    public class HourlyTemperatureModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public HourlyTemperatureModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.HourlyTemperatureRegion, typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}