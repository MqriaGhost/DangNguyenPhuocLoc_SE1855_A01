using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderDetailsService
    {
        List<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetailById(int orderDetailId);
        void AddOrderDetail(OrderDetails orderDetail);
        void UpdateOrderDetail(OrderDetails orderDetail);
        void DeleteOrderDetail(int orderDetailId);
        List<OrderDetails> SearchOrderDetails(string searchTerm);
    }
}
