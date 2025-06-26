using System.Windows;
using DangNguyenPhuocLocWPF.ViewModels;
using Services;

namespace DangNguyenPhuocLocWPF.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            // Pass both EmployeesService and CustomersService to the ViewModel
            DataContext = new LoginViewModel(new EmployeesService(), new CustomersService());

            // Handle password changes
            PasswordBox.PasswordChanged += (s, e) =>
            {
                if (DataContext is LoginViewModel viewModel)
                {
                    viewModel.Password = PasswordBox.Password;
                }
            };
        }
    }
}