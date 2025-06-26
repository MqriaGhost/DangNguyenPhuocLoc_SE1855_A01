using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System.Windows;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly ICustomersService _customerService;

        private Customers _currentCustomer;
        public Customers CurrentCustomer
        {
            get => _currentCustomer;
            set => SetProperty(ref _currentCustomer, value);
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public ICommand SaveChangesCommand { get; }

        // Add a parameterless constructor for design-time data context
        public ProfileViewModel() { }

        public ProfileViewModel(Customers customer)
        {
            _customerService = new CustomersService();
            CurrentCustomer = customer;
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }

        private void SaveChanges(object obj)
        {
            try
            {
                _customerService.UpdateCustomer(CurrentCustomer);
                StatusMessage = "Profile updated successfully!";
            }
            catch (System.Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}