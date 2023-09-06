﻿using Prism.Commands;
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
        }
    }
}
