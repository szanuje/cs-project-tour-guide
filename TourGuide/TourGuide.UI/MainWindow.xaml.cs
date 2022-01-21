using System.Windows;
using TourGuide.Domain.Data.Models;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user;   

        public MainWindow(User user)
        {
            InitializeComponent();

            this.user = user;
            this.navBar.user = user;
        }
    }
}
