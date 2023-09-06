using Prism.Commands;
using PrismWeatherApp.Core.Interfaces;

namespace PrismWeatherApp.Core
{
    public class AppCommands : IAppCommands
    {
        private CompositeCommand globalSearchCommand = new CompositeCommand();
        public CompositeCommand GlobalSearchCommand
        {
            get
            {
                return globalSearchCommand;
            }
        }
    }
}
