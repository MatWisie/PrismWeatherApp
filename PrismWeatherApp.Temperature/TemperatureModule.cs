using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWeatherApp.Core;
using PrismWeatherApp.Temperature.Views;

namespace PrismWeatherApp.Temperature
{
    public class TemperatureModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public TemperatureModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}