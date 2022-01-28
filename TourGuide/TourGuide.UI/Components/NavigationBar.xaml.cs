﻿// ***********************************************************************
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

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationBar"/> class.
        /// </summary>
        public NavigationBar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Click event of the ManagementButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ManagementButton_Click(object sender, RoutedEventArgs e)
        {
            var accountWindow = new AccountWindow(this.user);
            accountWindow.Show();
        }
    }
}
