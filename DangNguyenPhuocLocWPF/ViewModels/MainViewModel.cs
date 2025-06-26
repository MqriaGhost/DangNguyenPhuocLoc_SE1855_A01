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

        // Command Declarations
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowProductViewCommand { get; } // This property was likely missing

        public MainViewModel()
        {
            // Command Initializations
            ShowCustomerViewCommand = new RelayCommand(ShowCustomerView);
            ShowProductViewCommand = new RelayCommand(ShowProductView);

            // Set the initial view
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
    }
}