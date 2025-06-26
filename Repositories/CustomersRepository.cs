using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public void AddCustomer(Customers customer)
        {
            CustomersDAO.AddCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            CustomersDAO.DeleteCustomer(customerId);
        }

        public Customers GetCustomerById(int customerId)
        {
            return CustomersDAO.GetCustomerById(customerId);
        }

        public Customers GetCustomerByPhone(string phone)
        {
            return CustomersDAO.GetCustomerByPhone(phone);
        }

        public List<Customers> GetCustomers()
        {
            return CustomersDAO.GetAllCustomers();
        }

        public List<Customers> SearchCustomers(string searchTerm)
        {
            return CustomersDAO.SearchCustomers(searchTerm);
        }

        public void UpdateCustomer(Customers customer)
        {
            CustomersDAO.UpdateCustomer(customer);
        }
    }
}
