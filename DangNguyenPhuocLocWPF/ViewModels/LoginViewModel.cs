using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System;
using System.Windows;
using System.Windows.Input;
using DangNguyenPhuocLocWPF;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly ICustomersService _customersService;
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isCustomerLogin;

        public string Username
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
                ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool IsCustomerLogin
        {
            get => _isCustomerLogin;
            set
            {
                SetProperty(ref _isCustomerLogin, value);
                Username = string.Empty;
                Password = string.Empty;
                ErrorMessage = string.Empty;
                ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IEmployeesService employeesService, ICustomersService customersService)
        {
            _employeesService = employeesService;
            _customersService = customersService;
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object parameter)
        {
            if (IsCustomerLogin)
            {
                return !string.IsNullOrWhiteSpace(Username);
            }
            else
            {
                return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
            }
        }

        private void ExecuteLogin(object parameter)
        {
            ErrorMessage = string.Empty;

            try
            {
                if (IsCustomerLogin)
                {
                    var customer = _customersService.GetCustomerByPhone(Username);
                    if (customer != null)
                    {
                        var customerMainWindow = new Views.CustomerMainWindow(customer);
                        customerMainWindow.Show();
                        (parameter as Window)?.Close();
                    }
                    else
                    {
                        ErrorMessage = "Invalid phone number for customer login.";
                    }
                }
                else
                {
                    var employee = _employeesService.Login(Username, Password);
                    if (employee != null)
                    {
                        var mainWindow = new MainWindow();
                        mainWindow.Show();
                        (parameter as Window)?.Close();
                    }
                    else
                    {
                        ErrorMessage = "Invalid username or password for employee login.";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Login Error: {ex.Message}";
            }
        }
    }
}