using BusinessObjects;
using DangNguyenPhuocLocWPF.Commands;
using DangNguyenPhuocLocWPF.Views;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class OrderDisplay
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime OrderDate { get; set; }
        public Orders OriginalOrder { get; set; }
    }

    public class OrderViewModel : ViewModelBase
    {
        private readonly IOrdersService _ordersService;
        private readonly ICustomersService _customersService;
        private readonly IEmployeesService _employeesService;
        private readonly IOrderDetailsService _orderDetailsService;

        private Employees _loggedInEmployee;
        private ObservableCollection<OrderDisplay> _orders;
        public ObservableCollection<OrderDisplay> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }

        private OrderDisplay _selectedOrder;
        public OrderDisplay SelectedOrder
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

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public ICommand LoadOrdersCommand { get; }
        public ICommand FilterOrdersCommand { get; }
        public ICommand CreateOrderCommand { get; }

        // Add this empty constructor for the XAML Designer
        public OrderViewModel() { }

        public OrderViewModel(Employees employee)
        {
            _loggedInEmployee = employee;
            _ordersService = new OrdersService();
            _customersService = new CustomersService();
            _employeesService = new EmployeesService();
            _orderDetailsService = new OrderDetailsService();
            LoadOrdersCommand = new RelayCommand(LoadOrders);
            FilterOrdersCommand = new RelayCommand(FilterOrders, CanFilter);
            CreateOrderCommand = new RelayCommand(CreateOrder);

            EndDate = DateTime.Now;
            StartDate = EndDate.Value.AddMonths(-1);
            LoadOrders(null);
        }
        private void CreateOrder(object obj)
        {
            var createOrderWindow = new CreateOrderView(_loggedInEmployee);
            if (createOrderWindow.ShowDialog() == true)
            {
                LoadOrders(null);
            }
        }
        private bool CanFilter(object obj)
        {
            return StartDate.HasValue && EndDate.HasValue;
        }

        private void FilterOrders(object obj)
        {
            var orders = _ordersService.GetOrdersByPeriod(StartDate.Value, EndDate.Value);
            var customers = _customersService.GetCustomers();
            var employees = _employeesService.GetEmployees();

            var orderDisplayList = from o in orders
                                   join c in customers on o.CustomerId equals c.CustomerId
                                   join e in employees on o.EmployeeId equals e.EmployeeId
                                   select new OrderDisplay
                                   {
                                       OrderId = o.OrderId,
                                       CustomerName = c.ContactName,
                                       EmployeeName = e.Name,
                                       OrderDate = o.OrderDate,
                                       OriginalOrder = o
                                   };
            Orders = new ObservableCollection<OrderDisplay>(orderDisplayList);
        }

        private void LoadOrders(object obj)
        {
            var orders = _ordersService.GetOrders();
            var customers = _customersService.GetCustomers();
            var employees = _employeesService.GetEmployees();

            var orderDisplayList = from o in orders
                                   join c in customers on o.CustomerId equals c.CustomerId
                                   join e in employees on o.EmployeeId equals e.EmployeeId
                                   select new OrderDisplay
                                   {
                                       OrderId = o.OrderId,
                                       CustomerName = c.ContactName,
                                       EmployeeName = e.Name,
                                       OrderDate = o.OrderDate,
                                       OriginalOrder = o
                                   };
            Orders = new ObservableCollection<OrderDisplay>(orderDisplayList);
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