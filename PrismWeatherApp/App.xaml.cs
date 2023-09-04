using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismWeatherApp.Core;
using PrismWeatherApp.Core.Interfaces;
using PrismWeatherApp.Menu;
using PrismWeatherApp.Search;
using PrismWeatherApp.Temperature;
using PrismWeatherApp.Views;
using System.Windows;

namespace PrismWeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppCommands, AppCommands>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MenuModule>();
            moduleCatalog.AddModule<TemperatureModule>();
            moduleCatalog.AddModule<SearchModule>();
        }
    }
}
