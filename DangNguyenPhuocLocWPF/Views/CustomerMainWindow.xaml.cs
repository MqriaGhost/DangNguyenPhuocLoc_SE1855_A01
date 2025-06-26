using System.Windows;
using BusinessObjects;

namespace DangNguyenPhuocLocWPF.Views
{
    public partial class CustomerMainWindow : Window
    {
        private Customers _loggedInCustomer;

        public CustomerMainWindow()
        {
            InitializeComponent();
        }

        public CustomerMainWindow(Customers customer) : this()
        {
            _loggedInCustomer = customer;
            this.Title = $"Customer Dashboard - Welcome, {_loggedInCustomer.ContactName}";
        }
    }
}