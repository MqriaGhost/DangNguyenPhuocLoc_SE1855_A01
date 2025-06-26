using DangNguyenPhuocLocWPF.Commands;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowProductViewCommand { get; }
        public ICommand ShowOrderViewCommand { get; }

        public MainViewModel()
        {
            ShowCustomerViewCommand = new RelayCommand(ShowCustomerView);
            ShowProductViewCommand = new RelayCommand(ShowProductView);
            ShowOrderViewCommand = new RelayCommand(ShowOrderView);

            // Set the initial view to be the customer view
            CurrentView = new CustomerViewModel();
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
            CurrentView = new OrderViewModel();
        }
    }
}