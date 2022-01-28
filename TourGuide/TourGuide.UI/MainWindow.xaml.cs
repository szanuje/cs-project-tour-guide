// ***********************************************************************
// Assembly         : TourGuide.UI
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="MainWindow.xaml.cs" company="TourGuide.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TourGuide.Domain.Data.Models;
using TourGuide.Domain.Services;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="name">The name.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    /// <summary>
    /// Class RelayCommand.
    /// Implements the <see cref="System.Windows.Input.ICommand" />
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    class RelayCommand : ICommand
    {
        /// <summary>
        /// The execute
        /// </summary>
        private Action<object> _execute;
        /// <summary>
        /// The can execute
        /// </summary>
        private Func<object, bool> _canExecute;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <returns><see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null == _canExecute(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

    /// <summary>
    /// Class MainWindow.
    /// Implements the <see cref="System.Windows.Window" />
    /// Implements the <see cref="System.Windows.Markup.IComponentConnector" />
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The user
        /// </summary>
        public User user;

        /// <summary>
        /// The selected places
        /// </summary>
        public IList<Place> selectedPlaces;
        /// <summary>
        /// The user trips
        /// </summary>
        public IList<Place> userTrips;
        /// <summary>
        /// The destinations
        /// </summary>
        public IList<Destination> destinations;
        /// <summary>
        /// The hotels
        /// </summary>
        public ICollection<Hotel> hotels;
        /// <summary>
        /// The places to remove
        /// </summary>
        public IList<Place> placesToRemove;

        /// <summary>
        /// The selected destination
        /// </summary>
        public Destination selectedDestination;

        /// <summary>
        /// The destination service
        /// </summary>
        public DestinationService destinationService;
        /// <summary>
        /// The location service
        /// </summary>
        public UserLocationService locationService;
        /// <summary>
        /// The hotel service
        /// </summary>
        public HotelService hotelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public MainWindow(User user)
        {
            InitializeComponent();

            this.user = user;
            this.navBar.user = user;
            this.navBar.setUsernameUI();

            this.destinationService = new DestinationService();
            this.locationService = new UserLocationService();
            this.hotelService = new HotelService();

            this.destinations = destinationService.GetAllDestinations();
            this.DestinationList.ItemsSource = destinations;

            this.userTrips = locationService.GetAllUserPlaces(user.Username);
            this.UserTripList.ItemsSource = userTrips;

            this.hotels = hotelService.GetAllHotelsForTrip(userTrips);
            this.HotelList.ItemsSource = hotels;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the DestinationList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void DestinationList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Destination selectedDest = (Destination)(e.AddedItems[0]);
            if (selectedDest != null)
            {
                loadPlacesOnDestinationSet(selectedDest);
                switchToPlacesStack();
            }
        }

        /// <summary>
        /// Loads the places on destination set.
        /// </summary>
        /// <param name="selectedDestination">The selected destination.</param>
        private void loadPlacesOnDestinationSet(Destination selectedDestination)
        {
            var placesUIList = (System.Windows.Controls.ListView)this.FindName("PlacesList");
            placesUIList.ItemsSource = selectedDestination.Places;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the PlacesList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void PlacesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.selectedPlaces = new List<Place>();

            if (e.AddedItems.Count > 0)
            {
                this.PlacesButtonAdd.Visibility = Visibility.Visible;
                foreach (var place in e.AddedItems)
                {
                    this.selectedPlaces.Add(place as Place);
                }
            }
            else
            {
                this.PlacesButtonAdd.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Goes the back to destination menu.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void goBackToDestinationMenu(object sender, RoutedEventArgs e)
        {
            switchToDestinationStack();
        }

        /// <summary>
        /// Switches to places stack.
        /// </summary>
        private void switchToPlacesStack()
        {
            this.DestinationPanel.Visibility = Visibility.Collapsed;
            this.TripPanel.Visibility = Visibility.Collapsed;
            this.HotelPanel.Visibility = Visibility.Collapsed;

            this.PlacesPanel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Switches to destination stack.
        /// </summary>
        private void switchToDestinationStack()
        {
            this.PlacesPanel.Visibility = Visibility.Collapsed;
            this.TripPanel.Visibility = Visibility.Collapsed;
            this.HotelPanel.Visibility = Visibility.Collapsed;

            this.DestinationPanel.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Switches to trip stack.
        /// </summary>
        private void switchToTripStack()
        {
            this.DestinationPanel.Visibility = Visibility.Collapsed;
            this.PlacesPanel.Visibility = Visibility.Collapsed;
            this.HotelPanel.Visibility = Visibility.Collapsed;

            this.TripPanel.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Switches to hotel stack.
        /// </summary>
        private void switchToHotelStack()
        {
            this.DestinationPanel.Visibility = Visibility.Collapsed;
            this.PlacesPanel.Visibility = Visibility.Collapsed;
            this.TripPanel.Visibility = Visibility.Collapsed;

            this.HotelPanel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles the Click event of the PlacesButtonAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void PlacesButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var place in this.selectedPlaces)
            {
                this.locationService.AddLocationToUser(place.LocationId, this.user.Username);
            }
            this.RefreshUserTrips(this.user.Username);
            switchToDestinationStack();
        }

        /// <summary>
        /// Refreshes the user trips.
        /// </summary>
        /// <param name="username">The username.</param>
        private void RefreshUserTrips(string username)
        {
            var userTripUIList = (System.Windows.Controls.ListView)this.FindName("UserTripList");
            List<Place> places = locationService.GetAllUserPlaces(username);
            userTripUIList.ItemsSource = places;
            this.RefreshHotels(places);
        }

        /// <summary>
        /// Refreshes the hotels.
        /// </summary>
        /// <param name="places">The places.</param>
        private void RefreshHotels(IList<Place> places)
        {
            var hotelUIList = (System.Windows.Controls.ListView)this.FindName("HotelList");
            hotelUIList.ItemsSource = hotelService.GetAllHotelsForTrip(places);
        }

        /// <summary>
        /// Handles the Click event of the ExploreMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExploreMenu_Click(object sender, RoutedEventArgs e)
        {
            this.ExploreMenu.IsChecked = true;
            switchToDestinationStack();
        }

        /// <summary>
        /// Handles the Click event of the HotelsMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void HotelsMenu_Click(object sender, RoutedEventArgs e)
        {
            this.HotelsMenu.IsChecked = true;
            switchToHotelStack();

        }
        /// <summary>
        /// Handles the Click event of the TripMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TripMenu_Click(object sender, RoutedEventArgs e)
        {
            this.TripMenu.IsChecked = true;
            switchToTripStack();
        }
        /// <summary>
        /// Handles the SelectionChanged event of the UserTripList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void UserTripList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.placesToRemove = new List<Place>();

            if (e.AddedItems.Count > 0)
            {
                this.TripRemove.Visibility = Visibility.Visible;
                foreach (var place in e.AddedItems)
                {
                    this.placesToRemove.Add(place as Place);
                }
            }
            else
            {
                this.TripRemove.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Handles the Click event of the TripRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TripRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (var place in this.placesToRemove)
            {
                this.locationService.RemoveLocationFromUser(place.LocationId, this.user.Username);
            }
            this.RefreshUserTrips(this.user.Username);
        }
    }
}
