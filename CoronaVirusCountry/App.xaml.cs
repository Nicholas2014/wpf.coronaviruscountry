﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CoronaVirusCountry.Services;
using CoronaVirusCountry.ViewModels;

namespace CoronaVirusCountry
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var main = new MainWindow() { DataContext = new MainViewModel() };
            main.Show();

            base.OnStartup(e);
        }
    }
}
