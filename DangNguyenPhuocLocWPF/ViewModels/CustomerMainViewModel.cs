using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using DangNguyenPhuocLocWPF.Views;
using System.Windows;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class CustomerMainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand ShowProfileViewCommand { get; }
        public ICommand ShowOrderHistoryViewCommand { get; }
        public ICommand LogoutCommand { get; }

        public CustomerMainViewModel(Customers customer)
        {
            // We will create these ViewModels in the next steps
            var profileViewModel = new ProfileViewModel(customer);
            var orderHistoryViewModel = new OrderHistoryViewModel(customer);

            ShowProfileViewCommand = new RelayCommand(p => CurrentView = profileViewModel);
            ShowOrderHistoryViewCommand = new RelayCommand(p => CurrentView = orderHistoryViewModel);
            LogoutCommand = new RelayCommand(Logout);
            // Set the initial view to be the customer's profile
            CurrentView = profileViewModel;
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
    }
}