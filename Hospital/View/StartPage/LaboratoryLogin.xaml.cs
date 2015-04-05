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
using Hospital.View.Laboratory;
using Hospital.DataAccess.Util;

namespace Hospital.View.StartPage
{
    /// <summary>
    /// Interaction logic for LaboratoryLogin.xaml
    /// </summary>
    public partial class LaboratoryLogin : Window
    {
        public LaboratoryLogin()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Database database = new Database();
            String result = database.selectSingleQuery(String.Format("SELECT * FROM passwords WHERE username='{0}' AND password='{1}'", this.login.Text, this.password.Password));

            if (result == "")
            {
                this.errorMessage.Text = "Incorrect login or password";
            }
            else
            {
                LaboratoryWindow window = new LaboratoryWindow();
                window.Show();
                this.Close();
            }
        }
    }
}
