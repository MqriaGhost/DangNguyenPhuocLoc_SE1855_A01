using BusinessObjects;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class ProductDialogViewModel : ViewModelBase
    {
        private Products _product;

        public Products Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public ProductDialogViewModel(Products product)
        {
            // Create a copy to avoid changing the original product until "Save" is clicked
            Product = new Products
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };
        }
    }
}