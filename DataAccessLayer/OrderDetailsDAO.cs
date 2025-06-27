using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDetailsDAO
    {
        public static List<OrderDetails> orderDetails = new List<OrderDetails>
        {
    new OrderDetails { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 18.00, Discount = 0.0 },
    new OrderDetails { OrderId = 2, ProductId = 2, Quantity = 12, UnitPrice = 19.00, Discount = 0.1 },
    new OrderDetails { OrderId = 3, ProductId = 3, Quantity = 23, UnitPrice = 20.00, Discount = 0.2 }
    
        };
        public static List<OrderDetails> GetAllOrderDetails()
        {
            return orderDetails;
        }
        public static void AddOrderDetail(OrderDetails orderDetail) => orderDetails.Add(orderDetail);
        public static void UpdateOrderDetail(OrderDetails orderDetail)
        {
            var existingOrderDetail = orderDetails.FirstOrDefault(od => od.OrderId == orderDetail.OrderId && od.ProductId == orderDetail.ProductId);
            if (existingOrderDetail != null)
            {
                existingOrderDetail.Quantity = orderDetail.Quantity;
                existingOrderDetail.UnitPrice = orderDetail.UnitPrice;
                existingOrderDetail.Discount = orderDetail.Discount;
            }
        }
        public static void DeleteOrderDetail(int orderId)
        {
            var orderDetailToRemove = orderDetails.FirstOrDefault(od => od.OrderId == orderId);
            if (orderDetailToRemove != null)
            {
                orderDetails.Remove(orderDetailToRemove);
            }
        }
        public static List<OrderDetails> SearchOrderDetails(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<OrderDetails>(orderDetails);
            return orderDetails
                .Where(od => od.OrderId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.ProductId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.Quantity.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.UnitPrice.ToString("F2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.Discount.ToString("F2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public static OrderDetails GetOrderDetailById(int orderId)
        {
            return orderDetails.FirstOrDefault(od => od.OrderId == orderId);
        }
    }
}
