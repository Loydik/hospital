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
using System.Windows.Shapes;
using Hospital.ViewModel.Reception;

namespace Hospital.View.Reception
{
    /// <summary>
    /// Interaction logic for RegisterPatientWindow.xaml
    /// </summary>
    public partial class RegisterPatientWindow : Window
    {
        public RegisterPatientWindow()
        {
           
            InitializeComponent();
            RegisterPatientWindowViewModel vm = new RegisterPatientWindowViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
