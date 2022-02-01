// ***********************************************************************
// Assembly         : TourGuide.UI
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-30-2022
// ***********************************************************************
// <copyright file="RegisterWindow.xaml.cs" company="TourGuide.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows;
using System.Windows.Media;
using TourGuide.Domain.Services;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        /// <summary>
        /// The user service
        /// </summary>
        private UserService userService = new UserService();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterWindow" /> class.
        /// </summary>
        public RegisterWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the PasswordChanged event of the passwordConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void passwordConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(username.Text.Length > 0
                && passwordConfirm.Password.Length > 0
                && password.Password == passwordConfirm.Password
                && name.Text.Length > 0
                && surname.Text.Length > 0)
            {
                userSubmit.Background = new SolidColorBrush(Color.FromRgb(0, 98, 255));
                userSubmit.IsEnabled = true;
            }
            else
            {
                userSubmit.Background = new SolidColorBrush(Color.FromRgb(224, 224, 224));
                userSubmit.IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the userSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void userSubmit_Click(object sender, RoutedEventArgs e)
        {
            var response = userService.AddNewUser(username.Text, name.Text, surname.Text, password.Password);

            if (response)
            {
                this.switchToLogin();
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the backLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs" /> instance containing the event data.</param>
        private void backLabel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.switchToLogin();
        }

        /// <summary>
        /// Switches to login.
        /// </summary>
        private void switchToLogin()
        {
            LoginWindow loginScreen = new LoginWindow();
            loginScreen.Show();
            this.Close();
        }
    }
}
