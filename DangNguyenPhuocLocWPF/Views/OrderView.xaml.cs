using System.Windows.Controls;
using DangNguyenPhuocLocWPF.ViewModels;

namespace DangNguyenPhuocLocWPF.Views
{
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
            var viewModel = (OrderViewModel)DataContext;
            viewModel.LoadOrdersCommand.Execute(null);
        }
    }
}