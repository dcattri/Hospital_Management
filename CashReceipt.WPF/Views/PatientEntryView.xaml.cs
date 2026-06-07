using System.Windows;
using System.Windows.Controls;
using CashReceipt.WPF.Models;
using CashReceipt.WPF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashReceipt.WPF.Views
{
    public partial class PatientEntryView : UserControl
    {
        private readonly IPatientRepository _repo;
        public PatientEntryView()
        {
            InitializeComponent();
            _repo = ((App)Application.Current).Host.Services.GetService<IPatientRepository>();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var p = new Patient { Name = TxtName.Text, Phone = TxtPhone.Text };
            if (_repo != null)
            {
                await _repo.AddAsync(p);
                MessageBox.Show($"Saved patient: {p.Name} - {p.Phone}", "Patient", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Repository not available", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}