using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hospital.ViewModel.Laboratory;
using Hospital.View.Laboratory;
using Hospital.View.StartPage;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            StartPage app = new StartPage();
            //LaboratoryViewModel context = new LaboratoryViewModel();
            //app.DataContext = context;
            app.Show();
        }
    }
}
