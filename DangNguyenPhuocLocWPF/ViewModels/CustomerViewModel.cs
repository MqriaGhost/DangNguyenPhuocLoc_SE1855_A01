using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using DangNguyenPhuocLocWPF.Views;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomersService _customerService;
        private ObservableCollection<Customers> _customers;
        public ObservableCollection<Customers> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        private Customers _selectedCustomer;
        public Customers SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public CustomerViewModel()
        {
            _customerService = new CustomersService();
            SearchCommand = new RelayCommand(SearchCustomers);
            AddCommand = new RelayCommand(AddCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer, CanUpdateOrDelete);
            DeleteCommand = new RelayCommand(DeleteCustomer, CanUpdateOrDelete);

            // Load data immediately upon creation
            LoadCustomers(null);
        }

        private void LoadCustomers(object obj)
        {
            var customerList = _customerService.GetCustomers();
            Customers = new ObservableCollection<Customers>(customerList);
        }

        private bool CanUpdateOrDelete(object obj)
        {
            return SelectedCustomer != null;
        }

        private void SearchCustomers(object obj)
        {
            var customerList = _customerService.SearchCustomers(SearchTerm);
            Customers = new ObservableCollection<Customers>(customerList);
        }

        private void AddCustomer(object obj)
        {
            var newCustomer = new Customers();
            var dialogVM = new CustomerDialogViewModel(newCustomer);
            var dialog = new CustomerDialog
            {
                DataContext = dialogVM,
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                _customerService.AddCustomer(dialogVM.Customer);
                LoadCustomers(null);
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
                LoadCustomers(null);
            }
        }

        private void DeleteCustomer(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustomer(SelectedCustomer.CustomerId);
                LoadCustomers(null);
            }
        }
    }
}