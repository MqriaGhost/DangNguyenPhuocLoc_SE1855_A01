using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderDetailsRepository
    {
        List<OrderDetails> GetOrderDetails();
        void AddOrderDetail(OrderDetails orderDetail);
        void UpdateOrderDetail(OrderDetails orderDetail);
        void DeleteOrderDetail(int orderDetailId);
        List<OrderDetails> SearchOrderDetails(string searchTerm);
        OrderDetails GetOrderDetailById(int orderDetailId);
    }
}
