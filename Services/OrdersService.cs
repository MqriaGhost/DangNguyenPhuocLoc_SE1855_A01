using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository iorderRepository;
        public OrdersService()
        {
            // Assuming a concrete implementation of IOrderRepository is available
            iorderRepository = new OrdersRepository(); // Replace with actual repository instantiation
        }
        public void AddOrder(Orders order)
        {
            iorderRepository.AddOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            iorderRepository.DeleteOrder(orderId);
        }

        public Orders GetOrderById(int orderId)
        {
            return iorderRepository.GetOrderById(orderId);
        }

        public List<Orders> GetOrders()
        {
            return iorderRepository.GetOrders();
        }

        public List<Orders> GetOrdersByPeriod(DateTime startDate, DateTime endDate)
        {
            return iorderRepository.GetOrdersByPeriod(startDate, endDate);
        }

        public List<Orders> SearchOrders(string searchTerm)
        {
            return iorderRepository.SearchOrders(searchTerm);
        }

        public void UpdateOrder(Orders order)
        {
            iorderRepository.UpdateOrder(order);
        }
    }
}
