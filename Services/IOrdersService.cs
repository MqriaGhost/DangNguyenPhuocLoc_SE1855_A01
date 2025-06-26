using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrdersService
    {
        List<Orders> GetOrders();
        Orders GetOrderById(int orderId);
        void AddOrder(Orders order);
        void UpdateOrder(Orders order);
        void DeleteOrder(int orderId);
        List<Orders> SearchOrders(string searchTerm);
        List<Orders> GetOrdersByPeriod(DateTime startDate, DateTime endDate);
    }
}
