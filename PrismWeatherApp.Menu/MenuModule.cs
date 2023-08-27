using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWeatherApp.Core;
using PrismWeatherApp.Menu.Views;

namespace PrismWeatherApp.Menu
{
    public class MenuModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public MenuModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}