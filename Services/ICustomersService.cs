using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomersService
    {
        List<Customers> GetCustomers();
        Customers GetCustomerById(int customerId);
        void AddCustomer(Customers customer);
        void UpdateCustomer(Customers customer);
        void DeleteCustomer(int customerId);
        List<Customers> SearchCustomers(string searchTerm);
        Customers GetCustomerByPhone(string phone);
    }
}
