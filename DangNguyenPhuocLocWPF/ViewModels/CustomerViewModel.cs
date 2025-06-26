using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DangNguyenPhuocLocWPF.Views; // For the dialog
using System.Windows; // For MessageBox

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomersService _customerService;
        private ObservableCollection<Customers> _customers;
        private Customers _selectedCustomer;
        private string _searchTerm;

        public ObservableCollection<Customers> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        public Customers SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public ICommand LoadCustomersCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public CustomerViewModel()
        {
            _customerService = new CustomersService();
            LoadCustomersCommand = new RelayCommand(LoadCustomers);
            SearchCommand = new RelayCommand(SearchCustomers);
            AddCommand = new RelayCommand(AddCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer, CanUpdateOrDelete);
            DeleteCommand = new RelayCommand(DeleteCustomer, CanUpdateOrDelete);
        }

        private bool CanUpdateOrDelete(object obj)
        {
            // Can only update or delete if a customer is selected
            return SelectedCustomer != null;
        }

        private void SearchCustomers(object obj)
        {
            var customerList = _customerService.SearchCustomers(SearchTerm);
            Customers = new ObservableCollection<Customers>(customerList);
        }

        private void AddCustomer(object obj)
        {
            var newCustomer = new Customers(); // Create an empty customer
            var dialogVM = new CustomerDialogViewModel(newCustomer);

            var dialog = new CustomerDialog
            {
                DataContext = dialogVM,
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                _customerService.AddCustomer(dialogVM.Customer);
                LoadCustomers(null); // Reload the list to show the new customer
            }
        }

        private void UpdateCustomer(object obj)
        {
            var dialogVM = new CustomerDialogViewModel(SelectedCustomer);

            var dialog = new CustomerDialog
            {
                DataContext = dialogVM,
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                _customerService.UpdateCustomer(dialogVM.Customer);
                LoadCustomers(null); // Reload the list
            }
        }

        private void DeleteCustomer(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustomer(SelectedCustomer.CustomerId);
                LoadCustomers(null); // Reload the list
            }
        }

        private void LoadCustomers(object obj)
        {
            var customerList = _customerService.GetCustomers();
            Customers = new ObservableCollection<Customers>(customerList);
        }
    }
}