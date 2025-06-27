using BusinessObjects;
using DangNguyenPhuocLocWPF.ViewModels;
using System.Windows;

namespace DangNguyenPhuocLocWPF.Views
{
    public partial class CreateOrderView : Window
    {
        public CreateOrderView(Employees employee)
        {
            InitializeComponent();
            DataContext = new CreateOrderViewModel(employee);
        }
    }
}