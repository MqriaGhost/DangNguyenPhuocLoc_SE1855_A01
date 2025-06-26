using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository icustomerRepository;
        public CustomersService()
        {
            // Assuming a concrete implementation of ICustomerRepository is available
            icustomerRepository = new CustomersRepository(); // Replace with actual repository instantiation
        }
        public void AddCustomer(Customers customer)
        {
            icustomerRepository.AddCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            icustomerRepository.DeleteCustomer(customerId);
        }

        public Customers GetCustomerById(int customerId)
        {
            return icustomerRepository.GetCustomerById(customerId);
        }

        public Customers GetCustomerByPhone(string phone)
        {
            return icustomerRepository.GetCustomerByPhone(phone);
        }

        public List<Customers> GetCustomers()
        {
            return icustomerRepository.GetCustomers();
        }

        public List<Customers> SearchCustomers(string searchTerm)
        {
            return icustomerRepository.SearchCustomers(searchTerm);
        }

        public void UpdateCustomer(Customers customer)
        {
            icustomerRepository.UpdateCustomer(customer);
        }
    }
}
