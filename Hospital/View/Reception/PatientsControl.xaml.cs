using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Reception
{
    /// <summary>
    /// Interaction logic for PatientsControl.xaml
    /// </summary>
    public partial class PatientsControl : UserControl
    {
        public PatientsControl()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterPatientWindow window = new RegisterPatientWindow();
            window.Show();
        }

    }
}
