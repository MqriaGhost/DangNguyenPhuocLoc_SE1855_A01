using System.Windows;
using DangNguyenPhuocLocWPF.ViewModels;

namespace DangNguyenPhuocLocWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}