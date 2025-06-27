using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class CreateOrderViewModel : ViewModelBase
    {
        // Services
        private readonly ICustomersService _customersService;
        private readonly IProductsService _productsService;
        private readonly IOrdersService _ordersService;
        private readonly IOrderDetailsService _orderDetailsService;

        // Lists for ComboBoxes
        public ObservableCollection<Customers> Customers { get; set; }
        public ObservableCollection<Products> Products { get; set; }

        // New Order Properties
        public Orders NewOrder { get; set; }
        public ObservableCollection<OrderDetails> NewOrderDetails { get; set; }

        // Selected items for adding to the cart
        private Customers _selectedCustomer;
        public Customers SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        private Products _selectedProduct;
        public Products SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        private int _quantity = 1;
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        // Commands
        public ICommand AddToCartCommand { get; }
        public ICommand SaveOrderCommand { get; }

        public CreateOrderViewModel(Employees employee)
        {
            // Initialize services
            _customersService = new CustomersService();
            _productsService = new ProductsService();
            _ordersService = new OrdersService();
            _orderDetailsService = new OrderDetailsService();

            // Load data for dropdowns
            Customers = new ObservableCollection<Customers>(_customersService.GetCustomers());
            Products = new ObservableCollection<Products>(_productsService.GetProducts());

            // Initialize the new order object
            NewOrder = new Orders
            {
                EmployeeId = employee.EmployeeId,
                OrderDate = DateTime.Now
            };
            NewOrderDetails = new ObservableCollection<OrderDetails>();

            // Initialize Commands
            AddToCartCommand = new RelayCommand(AddToCart, CanAddToCart);
            SaveOrderCommand = new RelayCommand(SaveOrder, CanSaveOrder);
        }

        private bool CanAddToCart(object obj) => SelectedProduct != null && Quantity > 0;
        private bool CanSaveOrder(object obj) => SelectedCustomer != null && NewOrderDetails.Any();

        private void AddToCart(object obj)
        {
            var newDetail = new OrderDetails
            {
                ProductId = SelectedProduct.ProductId,
                UnitPrice = SelectedProduct.UnitPrice,
                Quantity = this.Quantity,
                Discount = 0 // You could add a field for this if needed
            };
            NewOrderDetails.Add(newDetail);
        }

        private void SaveOrder(object obj)
        {
            try
            {
                // Assign the selected customer to the order
                NewOrder.CustomerId = SelectedCustomer.CustomerId;

                // Save the main order record first
                _ordersService.AddOrder(NewOrder);

                // Now that the order has an ID, assign it to each detail and save them
                foreach (var detail in NewOrderDetails)
                {
                    detail.OrderId = NewOrder.OrderId;
                    _orderDetailsService.AddOrderDetail(detail);
                }

                MessageBox.Show("Order created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Close the window by finding it from the button that was clicked
                if (obj is Window window)
                {
                    window.DialogResult = true;
                    window.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save order. Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}