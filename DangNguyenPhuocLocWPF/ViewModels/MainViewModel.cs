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

        public MainViewModel()
        {
            // The command that will switch the view to the CustomerView
            ShowCustomerViewCommand = new RelayCommand(ShowCustomerView);

            // Set the initial view
            CurrentView = new CustomerViewModel();
        }

        private void ShowCustomerView(object obj)
        {
            CurrentView = new CustomerViewModel();
        }
    }
}