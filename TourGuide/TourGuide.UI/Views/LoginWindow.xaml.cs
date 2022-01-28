// ***********************************************************************
// Assembly         : TourGuide.UI
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-22-2022
// ***********************************************************************
// <copyright file="LoginWindow.xaml.cs" company="TourGuide.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows;
using System.Windows.Input;
using TourGuide.Domain.Services;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        /// <summary>
        /// The user service
        /// </summary>
        private UserService userService = new UserService();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWindow"/> class.
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates new profile_mousedown.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void NewProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow registerScreen = new RegisterWindow();
            registerScreen.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the userSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
