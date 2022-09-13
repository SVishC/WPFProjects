using FasettoWord.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FasettoWord
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// Custom startup so that we can load our IOC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Execute all the base first
            base.OnStartup(e);

            //Setup IoC
            IoC.Setup();

            //Show the Mainwindow
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
