using System.Windows;
using System.Windows.Media;
using TourGuide.Domain.Services;

namespace TourGuide.UI
{
    /// <summary>
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserService userService = new UserService();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void passwordConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(username.Text.Length > 0
                && passwordConfirm.Password.Length > 0
                && password.Password == passwordConfirm.Password)
            {
                userSubmit.Background = new SolidColorBrush(Color.FromRgb(0, 98, 255));
            } 
        }

        private void userSubmit_Click(object sender, RoutedEventArgs e)
        {
            var response = userService.AddNewUser(username.Text, password.Password);

            if (response)
            {
                this.switchToLogin();
            }
        }

        private void backLabel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.switchToLogin();
        }

        private void switchToLogin()
        {
            LoginWindow loginScreen = new LoginWindow();
            loginScreen.Show();
            this.Close();
        }
    }
}
