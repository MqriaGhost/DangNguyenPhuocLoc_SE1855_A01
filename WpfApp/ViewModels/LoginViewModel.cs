using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System;
using System.Windows;
using System.Windows.Input;
using WpfApp; // Assuming MainWindow is in the WpfApp namespace

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly ICustomersService _customersService; // Add ICustomersService
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isCustomerLogin; // New property to determine login type

        public string Username
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
                // Re-evaluate CanExecuteLogin when Username changes
                ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                // Re-evaluate CanExecuteLogin when Password changes
                ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool IsCustomerLogin // New property
        {
            get => _isCustomerLogin;
            set
            {
                SetProperty(ref _isCustomerLogin, value);
                // Clear inputs and error message when login type changes
                Username = string.Empty;
                Password = string.Empty;
                ErrorMessage = string.Empty;
                ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IEmployeesService employeesService, ICustomersService customersService) // Update constructor
        {
            _employeesService = employeesService;
            _customersService = customersService; // Initialize
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object parameter)
        {
            // Validation based on login type
            if (IsCustomerLogin)
            {
                // For customer login, only Phone (Username field) is required
                return !string.IsNullOrWhiteSpace(Username);
            }
            else
            {
                // For employee login, Username and Password are required
                return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
            }
        }

        private void ExecuteLogin(object parameter)
        {
            ErrorMessage = string.Empty; // Clear previous error messages

            try
            {
                if (IsCustomerLogin)
                {
                    // Customer login logic: use phone number
                    var customer = _customersService.GetCustomerByPhone(Username); // Username field used for phone
                    if (customer != null)
                    {
                        // TODO: Open customer-specific main window/dashboard
                        MessageBox.Show($"Welcome Customer: {customer.ContactName}!");
                        (parameter as Window)?.Close();
                    }
                    else
                    {
                        ErrorMessage = "Invalid phone number for customer login.";
                    }
                }
                else
                {
                    // Employee login logic: use username and password
                    var employee = _employeesService.Login(Username, Password);
                    if (employee != null)
                    {
                        // Open main window with admin role
                        var mainWindow = new MainWindow(employee); // Ensure MainWindow is in the Views namespace or adjust namespace as needed
                        mainWindow.Show();
                        // Close login window
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