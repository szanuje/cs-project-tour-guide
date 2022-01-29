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
using System.Collections.Generic;
using System.Windows;
using TourGuide.Domain.Data.Models;
using TourGuide.Domain.Services;

namespace TourGuide.UI.Views
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        private MainWindow _mainWindow;
        private DestinationService DestinationService;
        public ICollection<Destination> Destinations;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountWindow"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public ManagementWindow(MainWindow _mainWindow)
        {
            InitializeComponent();

            this._mainWindow = _mainWindow;

            this.DestinationService = new DestinationService();
            this.UpdateDestinations();
        }

        private void DestinationSList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void DestinationButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(this.DestinationNameBox.Text.Length > 0 && this.DestinationDescriptionBox.Text.Length > 0)
            {
                bool added = this.DestinationService.AddNewDestination(this.DestinationNameBox.Text, this.DestinationDescriptionBox.Text);

                if(added)
                {
                    this.DestinationNameBox.Text = "";
                    this.DestinationDescriptionBox.Text = "";
                    this.UpdateDestinations();
                    this._mainWindow.UpdateDestinations();
                }
            }
        }

        private void UpdateDestinations()
        {
            this.Destinations = this.DestinationService.GetAllDestinations();
            this.DestinationsList.ItemsSource = Destinations;
        }
    }
}
