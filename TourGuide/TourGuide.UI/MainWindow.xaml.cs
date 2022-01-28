using System.Collections.Generic;
using System.Windows;
using TourGuide.Domain.Data.Models;
using TourGuide.Domain.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;
using System.Diagnostics;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }

        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null == _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

    public partial class MainWindow : Window
    {
        public User user;
        
        public IList<Place> selectedPlaces;
        public IList<Place> userTrips;
        public IList<Destination> destinations;
        public ICollection<Hotel> hotels;
        public IList<Place> placesToRemove;

        public Destination selectedDestination;

        public DestinationService destinationService;
        public UserLocationService locationService;
        public HotelService hotelService;

        public MainWindow(User user)
        {
            InitializeComponent();

            this.user = user;
            this.navBar.user = user;

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

        private void DestinationList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Destination selectedDest = (Destination)(e.AddedItems[0]);
            if (selectedDest != null)
            {
                loadPlacesOnDestinationSet(selectedDest);
                switchToPlacesStack();
            }
        }

        private void loadPlacesOnDestinationSet(Destination selectedDestination)
        {
            var placesUIList = (System.Windows.Controls.ListView)this.FindName("PlacesList");
            placesUIList.ItemsSource = selectedDestination.Places;
        }

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

        private void goBackToDestinationMenu(object sender, RoutedEventArgs e)
        {
            switchToDestinationStack();
        }

        private void switchToPlacesStack()
        {
            this.DestinationPanel.Visibility = Visibility.Collapsed;
            this.TripPanel.Visibility = Visibility.Collapsed;
            this.HotelPanel.Visibility = Visibility.Collapsed;

            this.PlacesPanel.Visibility = Visibility.Visible;
        }

        private void switchToDestinationStack()
        {
            this.PlacesPanel.Visibility = Visibility.Collapsed;
            this.TripPanel.Visibility = Visibility.Collapsed;
            this.HotelPanel.Visibility = Visibility.Collapsed;

            this.DestinationPanel.Visibility = Visibility.Visible;
        }
        private void switchToTripStack()
        {
            this.DestinationPanel.Visibility = Visibility.Collapsed;
            this.PlacesPanel.Visibility = Visibility.Collapsed;
            this.HotelPanel.Visibility = Visibility.Collapsed;

            this.TripPanel.Visibility = Visibility.Visible;
        }
        private void switchToHotelStack()
        {
            this.DestinationPanel.Visibility = Visibility.Collapsed;
            this.PlacesPanel.Visibility = Visibility.Collapsed;
            this.TripPanel.Visibility = Visibility.Collapsed;

            this.HotelPanel.Visibility = Visibility.Visible;
        }

        private void PlacesButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var place in this.selectedPlaces)
            {
                this.locationService.AddLocationToUser(place.LocationId, this.user.Username);
            }
            this.RefreshUserTrips(this.user.Username);
            switchToDestinationStack();
        }

        private void RefreshUserTrips(string username)
        {
            var userTripUIList = (System.Windows.Controls.ListView)this.FindName("UserTripList");
            List<Place> places = locationService.GetAllUserPlaces(username);
            userTripUIList.ItemsSource = places;
            this.RefreshHotels(places);
        }

        private void RefreshHotels(IList<Place> places)
        {
            var hotelUIList = (System.Windows.Controls.ListView)this.FindName("HotelList");
            hotelUIList.ItemsSource = hotelService.GetAllHotelsForTrip(places);
        }

        private void ExploreMenu_Click(object sender, RoutedEventArgs e)
        {
            this.ExploreMenu.IsChecked = true;
            switchToDestinationStack();
        }

        private void HotelsMenu_Click(object sender, RoutedEventArgs e)
        {
            this.HotelsMenu.IsChecked = true;
            switchToHotelStack();

        }
        private void TripMenu_Click(object sender, RoutedEventArgs e)
        {
            this.TripMenu.IsChecked = true;
            switchToTripStack();
        }
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
