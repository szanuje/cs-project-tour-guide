// ***********************************************************************
// Assembly         : TourGuide.UI
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : ulmii
// Last Modified On : 01-22-2022
// ***********************************************************************
// <copyright file="ManagementWindow.xaml.cs" company="TourGuide.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TourGuide.Domain.Data.Models;
using TourGuide.Domain.Services;

namespace TourGuide.UI.Views
{
    /// <summary>
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        private MainWindow _mainWindow;
        private DestinationService DestinationService;
        public ICollection<Destination> Destinations;
        private Destination? SelectedDestination;

        private PlaceService PlaceService;
        public ICollection<Place> Places;
        private Place? SelectedPlace;

        private HotelService HotelService;
        public ICollection<Hotel> Hotels;
        private Hotel? SelectedHotel;

        public ManagementWindow(MainWindow _mainWindow)
        {
            InitializeComponent();

            this._mainWindow = _mainWindow;

            this.DestinationService = new DestinationService();
            this.PlaceService = new PlaceService();
            this.HotelService = new HotelService();

            this.UpdateDestinations();
        }

        private void DestinationsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.RemoveDestinationButton.Visibility = Visibility.Visible;
                this.AddHotelButton.Visibility = Visibility.Visible;
                this.AddPlaceButton.Visibility = Visibility.Visible;

                this.SelectedDestination = e.AddedItems[0] as Destination;
            }
            else
            {
                this.RemoveDestinationButton.Visibility = Visibility.Collapsed;
                this.AddHotelButton.Visibility = Visibility.Collapsed;
                this.AddPlaceButton.Visibility = Visibility.Collapsed;

                this.SelectedDestination = null;
            }
        }
        private void PlacesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.RemovePlaceButton.Visibility = Visibility.Visible;

                this.SelectedPlace = e.AddedItems[0] as Place;
            }
            else
            {
                this.RemovePlaceButton.Visibility = Visibility.Collapsed;

                this.SelectedPlace = null;
            }
        }
        private void HotelsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.RemoveHotelButton.Visibility = Visibility.Visible;

                this.SelectedHotel = e.AddedItems[0] as Hotel;
            }
            else
            {
                this.RemoveHotelButton.Visibility = Visibility.Collapsed;

                this.SelectedHotel = null;
            }
        }

        private void AddDestinationConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.DestinationNameBox.Text.Length > 0 && this.DestinationDescriptionBox.Text.Length > 0)
            {
                bool added = this.DestinationService.AddNewDestination(this.DestinationNameBox.Text, this.DestinationDescriptionBox.Text);

                if (added)
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
            this.DestinationsList.ItemsSource = this.Destinations;
        }
        private void UpdatePlaces()
        {
            if (this.SelectedDestination != null)
            {
                this.Places = this.PlaceService.GetPlacesForDestination(this.SelectedDestination.DestinationId);
                this.PlacesList.ItemsSource = this.Places;
            }
        }
        private void UpdateHotels()
        {
            if (this.SelectedDestination != null)
            {
                this.Hotels = this.HotelService.GetHotelsForDestination(this.SelectedDestination.DestinationId);
                this.HotelsList.ItemsSource = this.Hotels;
            }
        }

        private void AddHotelButton_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchToHotelPanel();
            this.UpdateHotels();
        }

        private void AddPlaceButton_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchToPlacePanel();
            this.UpdatePlaces();
        }

        private void SwitchToDestinationPanel()
        {
            this.PlacesPanel.Visibility = Visibility.Collapsed;
            this.AddNewPlacePanel.Visibility = Visibility.Collapsed;
            this.PlacesButtonsGrid.Visibility = Visibility.Collapsed;

            this.HotelsPanel.Visibility = Visibility.Collapsed;
            this.AddNewHotelPanel.Visibility = Visibility.Collapsed;
            this.HotelsButtonsGrid.Visibility = Visibility.Collapsed;

            this.DestinationsPanel.Visibility = Visibility.Visible;
            this.AddNewDestinationPanel.Visibility = Visibility.Visible;
            this.DestinationsButtonsGrid.Visibility = Visibility.Visible;
        }

        private void SwitchToPlacePanel()
        {
            this.DestinationsPanel.Visibility = Visibility.Collapsed;
            this.AddNewDestinationPanel.Visibility = Visibility.Collapsed;
            this.DestinationsButtonsGrid.Visibility = Visibility.Collapsed;

            this.PlacesPanel.Visibility = Visibility.Visible;
            this.AddNewPlacePanel.Visibility = Visibility.Visible;
            this.PlacesButtonsGrid.Visibility = Visibility.Visible;
        }
        private void SwitchToHotelPanel()
        {
            this.DestinationsPanel.Visibility = Visibility.Collapsed;
            this.AddNewDestinationPanel.Visibility = Visibility.Collapsed;
            this.DestinationsButtonsGrid.Visibility = Visibility.Collapsed;

            this.HotelsPanel.Visibility = Visibility.Visible;
            this.AddNewHotelPanel.Visibility = Visibility.Visible;
            this.HotelsButtonsGrid.Visibility = Visibility.Visible;
        }

        private void RemoveDestinationButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedDestination != null)
            {
                var result = this.DestinationService.RemoveDestination(this.SelectedDestination.DestinationId);

                if (result)
                {
                    this.UpdateHotels();
                    this.UpdatePlaces();
                    this.UpdateDestinations();
                    this._mainWindow.UpdatePlaces();
                    this._mainWindow.UpdateHotels();
                    this._mainWindow.UpdateDestinations();
                }
            }
        }

        private void RemoveHotelButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedHotel != null)
            {
                var result = this.HotelService.RemoveHotel(this.SelectedHotel.LocationId);

                if (result)
                {
                    this.UpdateHotels();
                    this.UpdatePlaces();
                    this._mainWindow.UpdateHotels();
                    this._mainWindow.UpdatePlaces();
                    this._mainWindow.switchToDestinationStack();
                }
            }
        }

        private void RemovePlaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedPlace != null && this.SelectedDestination != null)
            {
                var result = this.PlaceService.RemovePlace(this.SelectedPlace.LocationId);

                if (result)
                {
                    this.UpdatePlaces();
                    this._mainWindow.UpdatePlaces();
                    this._mainWindow.switchToDestinationStack();
                }
            }
        }

        private void AddPlaceConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedDestination != null
                && this.PlaceNameBox.Text.Length > 0 
                && this.PlaceDescriptionBox.Text.Length > 0
                && this.PlaceCityBox.Text.Length > 0
                && this.PlaceStreetBox.Text.Length > 0
                && this.PlacePostalCodeBox.Text.Length > 0
                && this.PlaceHouseNumberBox.Text.Length > 0)
            {
                var address = new Address()
                {
                    Country = this.SelectedDestination.Name,
                    Street = this.PlaceStreetBox.Text,
                    City = this.PlaceCityBox.Text,
                    PostalCode = this.PlacePostalCodeBox.Text,
                    HouseNumber = this.PlaceHouseNumberBox.Text
                };

                bool added = this.PlaceService.AddNewPlace(this.PlaceNameBox.Text, this.PlaceDescriptionBox.Text, this.SelectedDestination.DestinationId, address);

                if (added)
                {
                    this.PlaceNameBox.Text = "";
                    this.PlaceDescriptionBox.Text = "";
                    this.PlaceCityBox.Text = "";
                    this.PlaceStreetBox.Text = "";
                    this.PlacePostalCodeBox.Text = "";
                    this.PlaceHouseNumberBox.Text = "";

                    this.UpdatePlaces();
                    this._mainWindow.UpdatePlaces();
                    this._mainWindow.switchToDestinationStack();
                }
            }
        }
        private void AddHotelConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedDestination != null
                && this.HotelNameBox.Text.Length > 0
                && this.HotelRatingBox.Text.Length > 0
                && this.HotelPriceBox.Text.Length > 0
                && this.HotelCityBox.Text.Length > 0
                && this.HotelStreetBox.Text.Length > 0
                && this.HotelPostalCodeBox.Text.Length > 0
                && this.HotelHouseNumberBox.Text.Length > 0)
            {
                var address = new Address()
                {
                    Country = this.SelectedDestination.Name,
                    Street = this.HotelStreetBox.Text,
                    City = this.HotelCityBox.Text,
                    PostalCode = this.HotelPostalCodeBox.Text,
                    HouseNumber = this.HotelHouseNumberBox.Text
                };

                bool added = this.HotelService.AddNewHotel(this.HotelNameBox.Text, this.HotelRatingBox.Text, this.HotelPriceBox.Text, this.SelectedDestination.DestinationId, address);

                if (added)
                {
                    this.HotelNameBox.Text = "";
                    this.HotelRatingBox.Text = "";
                    this.HotelPriceBox.Text = "";
                    this.HotelCityBox.Text = "";
                    this.HotelStreetBox.Text = "";
                    this.HotelPostalCodeBox.Text = "";
                    this.HotelHouseNumberBox.Text = "";

                    this.UpdateHotels();
                    this._mainWindow.UpdateHotels();
                    this._mainWindow.switchToDestinationStack();
                }
            }
        }

        private void BackToDestinationsButton_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchToDestinationPanel();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
