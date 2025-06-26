using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
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

        public CustomerMainViewModel(Customers customer)
        {
            // We will create these ViewModels in the next steps
            var profileViewModel = new ProfileViewModel(customer);
            var orderHistoryViewModel = new OrderHistoryViewModel(customer);

            ShowProfileViewCommand = new RelayCommand(p => CurrentView = profileViewModel);
            ShowOrderHistoryViewCommand = new RelayCommand(p => CurrentView = orderHistoryViewModel);

            // Set the initial view to be the customer's profile
            CurrentView = profileViewModel;
        }
    }
}