using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        public void AddOrderDetail(OrderDetails orderDetail)
        {
            OrderDetailsDAO.AddOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int orderDetailId)
        {
            OrderDetailsDAO.DeleteOrderDetail(orderDetailId);
        }

        public OrderDetails GetOrderDetailById(int orderDetailId)
        {
            return OrderDetailsDAO.GetOrderDetailById(orderDetailId);
        }

        public List<OrderDetails> GetOrderDetails()
        {
            return OrderDetailsDAO.GetAllOrderDetails();
        }

        public List<OrderDetails> SearchOrderDetails(string searchTerm)
        {
            return OrderDetailsDAO.SearchOrderDetails(searchTerm);
        }

        public void UpdateOrderDetail(OrderDetails orderDetail)
        {
            OrderDetailsDAO.UpdateOrderDetail(orderDetail);
        }
    }
}
