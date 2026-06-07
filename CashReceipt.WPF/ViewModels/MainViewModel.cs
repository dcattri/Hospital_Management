using System.Collections.ObjectModel;

namespace CashReceipt.WPF.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<string> RecentPatients { get; } = new ObservableCollection<string>
        {
            "John Doe - 01/05/2026",
            "Jane Smith - 01/04/2026",
            "Bob Johnson - 12/30/2025"
        };
    }
}