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

namespace TourGuideUI
{
    /// <summary>
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void passwordConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(username.Text.Length > 0
                && passwordConfirm.Password.Length > 0
                && password.Password == passwordConfirm.Password)
            {
                userSubmit.Background = new SolidColorBrush(Color.FromRgb(0, 98, 255));
            } 
        }

        private void userSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }
    }
}
