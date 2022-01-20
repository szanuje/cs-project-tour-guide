using System;
using System.Windows;
using System.Windows.Input;
using TourGuide.service;

namespace TourGuideUI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserService userService = new UserService();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void NewProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow registerScreen = new RegisterWindow();
            registerScreen.Show();
            this.Close();
        }

        private void userSubmit_Click(object sender, RoutedEventArgs e)
        {
            var user = userService.LoginUser(username.Text, password.Password);

            if(user != null)
            {
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();

                this.Close();
            }
        }
    }
}
