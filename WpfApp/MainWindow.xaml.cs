using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects; // Make sure to include BusinessObjects namespace

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employees _loggedInEmployee; // Store the logged-in employee

        public MainWindow()
        {
            InitializeComponent();
        }

        // Add a constructor that accepts an Employee object
        public MainWindow(Employees employee) : this() // Calls the default constructor
        {
            _loggedInEmployee = employee;
            // You can now use _loggedInEmployee to determine what UI elements to show
            // or to pass to the MainWindow's ViewModel.
            this.Title = $"Sales Management System - Welcome, {_loggedInEmployee.Name} ({_loggedInEmployee.JobTitle})";
            // TODO: Set DataContext for MainWindow with a MainWindowViewModel that uses this employee object
        }
    }
}