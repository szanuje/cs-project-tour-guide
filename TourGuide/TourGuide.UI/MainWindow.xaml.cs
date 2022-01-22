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
    }
}
