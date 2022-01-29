// ***********************************************************************
// Assembly         : TourGuide.UI
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="NavigationBar.xaml.cs" company="TourGuide.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows;
using System.Windows.Controls;
using TourGuide.Domain.Data.Models;
using TourGuide.UI.Views;

namespace TourGuide.UI.Components
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        /// <summary>
        /// The user
        /// </summary>
        public User user;
        public MainWindow MainWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationBar"/> class.
        /// </summary>
        public NavigationBar()
        {
            InitializeComponent();
        }

        public void InitializeContent()
        {
            this.AccountNameLabel.Content = user.Name + " " + user.Surname + (user.Admin ? " (Admin)" : "");
            if (user.Admin)
            {
                this.ManagementButton.Visibility = Visibility.Visible;
            }
        }

        private void ManagementButton_Click(object sender, RoutedEventArgs e)
        {
            var managementWindow = new ManagementWindow(this.MainWindow);
            managementWindow.Show();
        }
    }
}
