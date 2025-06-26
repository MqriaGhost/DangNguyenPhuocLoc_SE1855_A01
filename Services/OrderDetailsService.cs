using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository iorderDetailRepository;
        public OrderDetailsService()
        {
            // Assuming a concrete implementation of IOrderDetailRepository is available
            iorderDetailRepository = new OrderDetailsRepository(); // Replace with actual repository instantiation
        }
        public void AddOrderDetail(OrderDetails orderDetail)
        {
            iorderDetailRepository.AddOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int orderDetailId)
        {
            iorderDetailRepository.DeleteOrderDetail(orderDetailId);
        }

        public OrderDetails GetOrderDetailById(int orderDetailId)
        {
            return iorderDetailRepository.GetOrderDetailById(orderDetailId);
        }

        public List<OrderDetails> GetOrderDetails()
        {
            return iorderDetailRepository.GetOrderDetails();
        }

        public List<OrderDetails> SearchOrderDetails(string searchTerm)
        {
            return iorderDetailRepository.SearchOrderDetails(searchTerm);
        }

        public void UpdateOrderDetail(OrderDetails orderDetail)
        {
            iorderDetailRepository.UpdateOrderDetail(orderDetail);
        }
    }
}
