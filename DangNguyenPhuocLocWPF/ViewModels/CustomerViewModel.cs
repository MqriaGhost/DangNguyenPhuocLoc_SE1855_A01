using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
            // We will implement the other commands later
        }

        private void LoadCustomers(object obj)
        {
            var customerList = _customerService.GetCustomers();
            Customers = new ObservableCollection<Customers>(customerList);
        }
    }
}