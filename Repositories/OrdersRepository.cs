using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public void AddOrder(Orders order)
        {
            OrdersDAO.AddOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            OrdersDAO.DeleteOrder(orderId);
        }

        public Orders GetOrderById(int orderId)
        {
            return OrdersDAO.GetOrderById(orderId);
        }

        public List<Orders> GetOrders()
        {
            return OrdersDAO.GetAllOrders();
        }

        public List<Orders> GetOrdersByPeriod(DateTime startDate, DateTime endDate)
        {
            return OrdersDAO.GetOrdersByPeriod(startDate, endDate);
        }

        public List<Orders> SearchOrders(string searchTerm)
        {
            return OrdersDAO.SearchOrders(searchTerm);
        }

        public void UpdateOrder(Orders order)
        {
            OrdersDAO.UpdateOrder(order);
        }
    }
}
