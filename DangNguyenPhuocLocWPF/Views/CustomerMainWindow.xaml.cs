using System.Windows;
using BusinessObjects;
using DangNguyenPhuocLocWPF.ViewModels; // Add this using statement

namespace DangNguyenPhuocLocWPF.Views
{
    public partial class CustomerMainWindow : Window
    {
        // The customer object passed from the login screen
        private Customers _loggedInCustomer;

        public CustomerMainWindow(Customers customer)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            // Set the DataContext to our new main ViewModel
            DataContext = new CustomerMainViewModel(_loggedInCustomer);
            this.Title = $"Customer Dashboard - Welcome, {_loggedInCustomer.ContactName}";
        }
    }
}