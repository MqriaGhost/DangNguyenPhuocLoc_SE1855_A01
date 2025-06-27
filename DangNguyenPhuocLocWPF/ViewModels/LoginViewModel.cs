using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using DangNguyenPhuocLocWPF.Views; // Required for the specific window views
using Services;
using System;
using System.Windows; // Required for MessageBox
using System.Windows.Input;

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

        public LoginViewModel() // Keep a parameterless constructor for the designer
        {
            _employeesService = new EmployeesService();
            _customersService = new CustomersService();
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        // This is the main constructor used at runtime
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
                    // Customer login logic
                    var customer = _customersService.GetCustomerByPhone(Username);
                    if (customer != null)
                    {
                        // *** ADD THIS: Success notification for customer ***
                        MessageBox.Show($"Welcome, {customer.ContactName}!", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                        var customerMainWindow = new CustomerMainWindow(customer);
                        customerMainWindow.Show();
                        (parameter as Window)?.Close();
                    }
                    else
                    {
                        // *** ADD THIS: Failure notification for customer ***
                        ErrorMessage = "Invalid phone number for customer login.";
                        MessageBox.Show(ErrorMessage, "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Employee login logic
                    var employee = _employeesService.Login(Username, Password);
                    if (employee != null)
                    {
                        // *** ADD THIS: Success notification for employee ***
                        MessageBox.Show($"Welcome, {employee.Name} ({employee.JobTitle})!", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                        var mainWindow = new MainWindow(employee);
                        mainWindow.Show();
                        (parameter as Window)?.Close();
                    }
                    else
                    {
                        // *** ADD THIS: Failure notification for employee ***
                        ErrorMessage = "Invalid username or password for employee login.";
                        MessageBox.Show(ErrorMessage, "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Login Error: {ex.Message}";
                MessageBox.Show(ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}