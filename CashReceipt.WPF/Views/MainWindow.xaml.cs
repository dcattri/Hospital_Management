using System.Windows;
using System.Windows.Controls;

namespace CashReceipt.WPF.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // start with login view
            ContentHost.Content = new LoginView();
        }

        private void Nav_Dashboard(object sender, RoutedEventArgs e)
        {
            ContentHost.Content = new MainContentView();
        }

        private void Nav_Patients(object sender, RoutedEventArgs e)
        {
            ContentHost.Content = new PatientEntryView();
        }
    }
}