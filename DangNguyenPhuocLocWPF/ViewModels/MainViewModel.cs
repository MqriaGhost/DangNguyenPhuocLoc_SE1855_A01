using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using DangNguyenPhuocLocWPF.Views;
using System.Windows;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        private Employees _loggedInEmployee;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowProductViewCommand { get; }
        public ICommand ShowOrderViewCommand { get; }
        public ICommand LogoutCommand { get; }
        public MainViewModel(Employees employee)
        {
            _loggedInEmployee = employee;
            ShowCustomerViewCommand = new RelayCommand(ShowCustomerView);
            ShowProductViewCommand = new RelayCommand(ShowProductView);
            ShowOrderViewCommand = new RelayCommand(ShowOrderView);
            LogoutCommand = new RelayCommand(Logout);

            // Set the initial view to be the customer view
            CurrentView = new CustomerViewModel();
        }
        private void Logout(object obj)
        {
            if (obj is Window window)
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                window.Close();
            }
        }

        private void ShowCustomerView(object obj)
        {
            CurrentView = new CustomerViewModel();
        }

        private void ShowProductView(object obj)
        {
            CurrentView = new ProductViewModel();
        }

        private void ShowOrderView(object obj)
        {
            CurrentView = new OrderViewModel(_loggedInEmployee);
        }
    }
}