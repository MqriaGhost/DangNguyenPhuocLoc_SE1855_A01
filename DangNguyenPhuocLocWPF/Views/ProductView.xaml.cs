using System.Windows.Controls;
using DangNguyenPhuocLocWPF.ViewModels;

namespace DangNguyenPhuocLocWPF.Views
{
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
            // When the view is created, get the ViewModel and load the products
            var viewModel = (ProductViewModel)DataContext;
            viewModel.LoadProductsCommand.Execute(null);
        }
    }
}