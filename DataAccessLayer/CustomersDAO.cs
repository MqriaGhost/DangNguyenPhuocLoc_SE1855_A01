using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomersDAO
    {
        public static List<Customers> customers = new List<Customers>
        {
        new Customers{
            CustomerId = 1,
            CompanyName = "Alfreds Futterkiste",
            ContactName = "Alfred Adler",
            ContactTitle = "Sales Representative",
            Address = "Obere Str. 57",
            Phone = "123456789" },
        new Customers{
            CustomerId = 2,
            CompanyName = "Ana Trujillo Emparedados y helados",
            ContactName = "Sigmund Freud",
            ContactTitle = "Owner",
            Address = "Avda. de la Constitución 2222",
            Phone = "987654321" },
        new Customers{
            CustomerId = 3,
            CompanyName = "Antonio Moreno Taquería",
            ContactName = "Carl Gustave Jung",
            ContactTitle = "Owner",
            Address = "Mataderos 2312",
            Phone = "456789123" },
        new Customers
        {
            CustomerId = 4,
            CompanyName = "2 The Moon",
            ContactName = "Frank Sinatra",
            ContactTitle = "Rekord Manager",
            Address = "120 Hanover Sq.",
            Phone = "321654987" },
        };

        public static List<Customers> GetAllCustomers()
        {
            return customers;
        }
        public static Customers GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.CustomerId == id);
        }
        public static void AddCustomer(Customers customer)
        {            
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer object cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
            {
                throw new Exception("Company name is required.");
            }
            if (string.IsNullOrWhiteSpace(customer.ContactName))
            {
                throw new Exception("Contact name is required.");
            }
            int maxId = customers.Count > 0 ? customers.Max(c => c.CustomerId) : 0;
            
            int newId = maxId + 1;
            customer.CustomerId = newId;         
            customers.Add(customer);
        }
        public static void UpdateCustomer(Customers customer)
        {
            
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer object cannot be null for update.");
            }

        
            var existingCustomer = customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

           
            if (existingCustomer == null)
            {
                throw new ArgumentException($"Customer with ID {customer.CustomerId} not found for update.", nameof(customer.CustomerId));
            }
           
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
            {
                throw new Exception("Company name cannot be empty or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(customer.ContactName))
            {
                throw new Exception("Contact name cannot be empty or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(customer.Phone))
            {
                throw new Exception("Phone number is required.");
            }                
            if (existingCustomer.Phone != customer.Phone)
            {
                if (customers.Any(c => c.Phone == customer.Phone))
                {
                    throw new Exception($"Phone number '{customer.Phone}' is already registered to another customer.");
                }
            }           
            existingCustomer.CompanyName = customer.CompanyName;
            existingCustomer.ContactName = customer.ContactName;
            existingCustomer.ContactTitle = customer.ContactTitle;
            existingCustomer.Address = customer.Address;
            existingCustomer.Phone = customer.Phone;
        }
        public static void DeleteCustomer(int customerId)
        {            
            var customerToRemove = customers.FirstOrDefault(c => c.CustomerId == customerId);          
            if (customerToRemove == null)
            {
                throw new ArgumentException($"Customer with ID {customerId} not found for deletion.", nameof(customerId));
            }            
            customers.Remove(customerToRemove);
        }
        public static List<Customers> SearchCustomers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Customers>(customers);
            return customers
                .Where(c => c.CompanyName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.ContactName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public static Customers GetCustomerByPhone(string phone)
        {
            return customers.FirstOrDefault(c => c.Phone == phone);
        }

    }
}
