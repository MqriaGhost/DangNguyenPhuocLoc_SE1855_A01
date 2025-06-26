using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrdersDAO
    {
        public static List<Orders> orders = new List<Orders>
        {
            new Orders
            {
                OrderId = 1,
                CustomerId = 1,
                EmployeeId = 1,
                OrderDate = new DateTime(2025, 10, 1)
            },
            new Orders
            {
                OrderId = 2,
                CustomerId = 2,
                EmployeeId = 2,
                OrderDate = new DateTime(2025, 10, 2)
            },
            new Orders
            {
                OrderId = 3,
                CustomerId = 3,
                EmployeeId = 1,
                OrderDate = new DateTime(2025, 10, 3)
            }
        };
        public static List<Orders> GetAllOrders()
        {
            return orders;
        }
        public static Orders GetOrderById(int id)
        {
            return orders.FirstOrDefault(o => o.OrderId == id);
        }
        public static void AddOrder(Orders order)
        {
            var maxId = orders.Any() ? orders.Max(o => o.OrderId) : 0;
            order.OrderId = maxId + 1;
            orders.Add(order);
        }
        public static void UpdateOrder(Orders order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.CustomerId = order.CustomerId;
                existingOrder.EmployeeId = order.EmployeeId;
                existingOrder.OrderDate = order.OrderDate;
            }
        }
        public static void DeleteOrder(int orderId)
        {
            var orderToRemove = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (orderToRemove != null)
            {
                orders.Remove(orderToRemove);
            }
        }
        public static List<Orders> SearchOrders(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Orders>(orders);
            return orders
                .Where(o => o.CustomerId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            o.EmployeeId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            o.OrderDate.ToString("d").Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public static List<Orders> GetOrdersByPeriod(DateTime startDate, DateTime endDate)
        {
            DateTime startOfDay = startDate.Date;
            DateTime endOfDay = endDate.Date.AddDays(1);
            return orders
                // Sửa lại điều kiện Where như sau:
                .Where(o => o.OrderDate >= startOfDay && o.OrderDate < endOfDay)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }
    }
}
