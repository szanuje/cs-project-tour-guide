using System;
using System.Windows;
using System.Windows.Input;
using TourGuide.service;

namespace TourGuideUI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private UserService userService = new UserService();

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void NewProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();
            registerScreen.Show();
            this.Close();
        }

        private void userSubmit_Click(object sender, RoutedEventArgs e)
        {
            var user = userService.LoginUser(username.Text, password.Password);

            Console.WriteLine("");
        }
    }
}
