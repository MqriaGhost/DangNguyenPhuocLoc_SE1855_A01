using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class OrderHistoryViewModel : ViewModelBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IOrderDetailsService _orderDetailsService;

        public Customers CurrentCustomer { get; set; }

        private ObservableCollection<Orders> _orders;
        public ObservableCollection<Orders> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }

        private Orders _selectedOrder;
        public Orders SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                LoadOrderDetails();
            }
        }

        private ObservableCollection<OrderDetails> _selectedOrderDetails;
        public ObservableCollection<OrderDetails> SelectedOrderDetails
        {
            get => _selectedOrderDetails;
            set => SetProperty(ref _selectedOrderDetails, value);
        }

        // We keep the command in case we need it for a "Refresh" button later.
        public ICommand LoadOrdersCommand { get; }

        public OrderHistoryViewModel() { } // Keep an empty constructor for the designer

        public OrderHistoryViewModel(Customers customer)
        {
            _ordersService = new OrdersService();
            _orderDetailsService = new OrderDetailsService();
            CurrentCustomer = customer;
            LoadOrdersCommand = new RelayCommand(LoadOrders);

            // *** THE FIX IS HERE: Load data immediately upon creation ***
            LoadOrders(null);
        }

        private void LoadOrders(object obj)
        {
            if (CurrentCustomer == null) return;

            var allOrders = _ordersService.GetOrders();
            var customerOrders = allOrders.Where(o => o.CustomerId == CurrentCustomer.CustomerId).ToList();
            Orders = new ObservableCollection<Orders>(customerOrders);
        }

        private void LoadOrderDetails()
        {
            if (SelectedOrder != null)
            {
                var allDetails = _orderDetailsService.GetOrderDetails();
                var detailsForOrder = allDetails.Where(d => d.OrderId == SelectedOrder.OrderId).ToList();
                SelectedOrderDetails = new ObservableCollection<OrderDetails>(detailsForOrder);
            }
            else
            {
                SelectedOrderDetails = new ObservableCollection<OrderDetails>();
            }
        }
    }
}