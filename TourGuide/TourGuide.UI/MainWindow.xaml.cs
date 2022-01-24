using System.Collections.Generic;
using System.Windows;
using TourGuide.Domain.Data.Models;
using TourGuide.Domain.Services;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user;
        public DestinationService destinationService;
        public Destination selectedDestination;
        public IList<Place> places = new List<Place>();
        public MainWindow(User user)
        {
            InitializeComponent();

            this.user = user;
            this.navBar.user = user;

            this.destinationService = new DestinationService();
            List<Destination> dests = destinationService.GetAllDestinations();

            this.DestinationList.ItemsSource = dests;
        }

        private void DestinationList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void DestinationList_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Destination selectedDest = (Destination)(e.AddedItems[0]);
            if (selectedDest != null) { 
                loadPlacesOnDestinationSet(selectedDest);
            }
        }

        private void loadPlacesOnDestinationSet(Destination selectedDestination) {
            var placesUIList = (System.Windows.Controls.ListView)this.FindName("PlacesList");
            placesUIList.Items.Clear();
            foreach (Place place in selectedDestination.Places) { // todo nie chcialo dodac wszystkich naraz z jakiegos powodu, potem zerkne na to, teraz mi sie nie chce
                placesUIList.Items.Add(place);
            }
            
        }

        private void PlacesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }
    }
}
