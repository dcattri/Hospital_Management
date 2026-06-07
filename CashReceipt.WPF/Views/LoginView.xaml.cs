using System.Windows;
using System.Windows.Controls;

namespace CashReceipt.WPF.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameText.Text;
            var password = PasswordBox.Password;
            // temporary simple authentication for POC
            if (username == "admin" && password == "password")
            {
                // navigate to main dashboard - host will be set by MainWindow
                var main = new MainContentView();
                var host = Window.GetWindow(this).FindName("ContentHost") as ContentControl;
                if (host != null) host.Content = main;
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}