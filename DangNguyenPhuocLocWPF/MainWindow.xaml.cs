using BusinessObjects;
using DangNguyenPhuocLocWPF.ViewModels;
using System.Windows;

namespace DangNguyenPhuocLocWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(Employees employee)
        {
            InitializeComponent();
            DataContext = new MainViewModel(employee);
        }
    }
}