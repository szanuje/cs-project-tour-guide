using System.Collections.Generic;
using System.Windows;
using TourGuide.Domain.Data.Models;
using TourGuide.Domain.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    class RelayCommand : ICommand 
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged { 
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }

        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            return _canExecute == null == _canExecute(parameter);
        }

        public void Execute(object parameter) {
            _execute(parameter);
        }

    }


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
                switchToPlacesStack();
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

        private void goBackToDestinationMenu(object sender, RoutedEventArgs e)
        {
            switchToDestinationStack();
        }



        private void switchToPlacesStack() {
            var destinationPanel = (System.Windows.Controls.StackPanel)this.FindName("DestinationPanel");
            destinationPanel.Visibility = Visibility.Collapsed;

            var placesPanel = (System.Windows.Controls.StackPanel)this.FindName("PlacesPanel");
            placesPanel.Visibility = Visibility.Visible;

/*            var style = this.FindResource("MenuButtonStyle") as Style;
            var exploreButton = (System.Windows.Controls.RadioButton)this.FindName("ExploreMenu");
            exploreButton.Style = style;

            var styleSelected = this.FindResource("MenuButtonStyleSelected") as Style;
            var placesButton = (System.Windows.Controls.RadioButton)this.FindName("PlacesMenu");
            placesButton.Style = styleSelected;*/

            /*            var style = Application.Current.Resources["MenuButtonStyle"] as Style;
                        var exploreButton = (System.Windows.Controls.RadioButton)this.FindName("ExploreMenu");
                        exploreButton.Style = style;

                        var styleSelected = Application.Current.Resources["MenuButtonStyleSelected"] as Style; // todo to też potem fixne, nie zmienia się to sadeg
                        var placesButton = (System.Windows.Controls.RadioButton)this.FindName("PlacesMenu");
                        placesButton.Style = styleSelected;*/
        }

        private void switchToDestinationStack()
        {
            
            var destinationPanel = (System.Windows.Controls.StackPanel)this.FindName("PlacesPanel");
            destinationPanel.Visibility = Visibility.Collapsed;

            var placesPanel = (System.Windows.Controls.StackPanel)this.FindName("DestinationPanel");
            placesPanel.Visibility = Visibility.Visible;

        }
    }
}
