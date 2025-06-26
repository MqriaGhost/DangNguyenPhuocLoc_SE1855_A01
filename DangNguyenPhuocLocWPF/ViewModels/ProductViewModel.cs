using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DangNguyenPhuocLocWPF.Views; // For the dialog
using System.Windows; // For MessageBox

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly IProductsService _productService;
        private ObservableCollection<Products> _products;
        private Products _selectedProduct;
        private string _searchTerm;

        public ObservableCollection<Products> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public Products SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public ICommand LoadProductsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public ProductViewModel()
        {
            _productService = new ProductsService();
            LoadProductsCommand = new RelayCommand(LoadProducts);
            SearchCommand = new RelayCommand(SearchProducts);
            AddCommand = new RelayCommand(AddProduct);
            UpdateCommand = new RelayCommand(UpdateProduct, CanUpdateOrDelete);
            DeleteCommand = new RelayCommand(DeleteProduct, CanUpdateOrDelete);
        }
        private bool CanUpdateOrDelete(object obj)
        {
            return SelectedProduct != null;
        }

        private void SearchProducts(object obj)
        {
            var productList = _productService.SearchProducts(SearchTerm);
            Products = new ObservableCollection<Products>(productList);
        }

        private void AddProduct(object obj)
        {
            var newProduct = new Products();
            var dialogVM = new ProductDialogViewModel(newProduct);

            var dialog = new ProductDialog
            {
                DataContext = dialogVM,
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                _productService.AddProduct(dialogVM.Product);
                LoadProducts(null); // Reload list
            }
        }

        private void UpdateProduct(object obj)
        {
            var dialogVM = new ProductDialogViewModel(SelectedProduct);

            var dialog = new ProductDialog
            {
                DataContext = dialogVM,
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                _productService.UpdateProduct(dialogVM.Product);
                LoadProducts(null); // Reload list
            }
        }

        private void DeleteProduct(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _productService.DeleteProduct(SelectedProduct.ProductId);
                LoadProducts(null); // Reload list
            }
        }

        private void LoadProducts(object obj)
        {
            var productList = _productService.GetProducts();
            Products = new ObservableCollection<Products>(productList);
        }
    }
}