using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomersRepository
    {
        List<Customers> GetCustomers();
        Customers GetCustomerById(int customerId);
        void AddCustomer(Customers customer);
        void UpdateCustomer(Customers customer);
        void DeleteCustomer(int customerId);
        Customers GetCustomerByPhone(string phone);

        List<Customers> SearchCustomers(string searchTerm);
    }
}
