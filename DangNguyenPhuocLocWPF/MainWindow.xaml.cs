using System.Windows;
using BusinessObjects;

namespace DangNguyenPhuocLocWPF
{
    public partial class MainWindow : Window
    {
        private Employees _loggedInEmployee;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Employees employee) : this()
        {
            _loggedInEmployee = employee;
            this.Title = $"Sales Management System - Welcome, {_loggedInEmployee.Name} ({_loggedInEmployee.JobTitle})";
        }
    }
}