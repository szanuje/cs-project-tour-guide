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
            System.Console.WriteLine("kupa");
            Destination selectedDest = (Destination)(e.AddedItems[0]);
            System.Console.WriteLine(e);
            System.Console.WriteLine(sender);
        }

        private void PlacesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }
    }
}
