﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Dayo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
		{
            Store store = new Store();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(store);
			MainWindow mainWindow = new MainWindow(mainWindowViewModel, store);
			mainWindow.Show();
		}
    }
}
