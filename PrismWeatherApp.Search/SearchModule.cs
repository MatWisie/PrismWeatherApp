using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWeatherApp.Core;
using PrismWeatherApp.Core.Interfaces;
using PrismWeatherApp.Search.Views;

namespace PrismWeatherApp.Search
{
    public class SearchModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public SearchModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.SearchRegion, typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISearchApiService, SearchApiService>();
        }
    }
}