using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourGuide.Domain.Data.Models;
using TourGuide.UI.Views;

namespace TourGuide.UI.Components
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public User user;

        public NavigationBar()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            var accountWindow = new AccountWindow(this.user);
            accountWindow.Show();
        }
    }
}
