// ***********************************************************************
// Assembly         : TourGuide.UI
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-22-2022
// ***********************************************************************
// <copyright file="AccountWindow.xaml.cs" company="TourGuide.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows;
using TourGuide.Domain.Data.Models;

namespace TourGuide.UI.Views
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountWindow"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public AccountWindow(User user)
        {
            InitializeComponent();

            this.usernameLabel.Content = user.Username;
        }
    }
}
