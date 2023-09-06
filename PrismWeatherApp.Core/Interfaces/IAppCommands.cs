using Prism.Commands;

namespace PrismWeatherApp.Core.Interfaces
{
    public interface IAppCommands
    {
        CompositeCommand GlobalSearchCommand { get; }
    }
}