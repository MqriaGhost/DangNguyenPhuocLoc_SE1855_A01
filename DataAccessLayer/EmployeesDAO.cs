using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeesDAO
    {
        private static List<Employees> employees = new List<Employees>
        {
            new Employees
            {
                EmployeeId = 1,
                Name = "Haruki Murakami",
                UserName = "murakami",
                Password = "123",
                JobTitle = "Software Engineer"
            },
            new Employees
            {
                EmployeeId = 2,
                Name = "Kawabata Yasunari",
                UserName = "yasunari",
                Password = "123",
                JobTitle = "Project Manager"
            }
        };
        public static List<Employees> GetAllEmployees()
        {
            return employees;
        }
        public static Employees GetEmployeeById(int employeeId)
        {
            return employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }
        public static void AddEmployee(Employees employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));            
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new ArgumentException("Employee name is required");
            if (string.IsNullOrWhiteSpace(employee.UserName))
                throw new ArgumentException("Username is required");
            if (string.IsNullOrWhiteSpace(employee.Password))
                throw new ArgumentException("Password is required");
            if (string.IsNullOrWhiteSpace(employee.JobTitle))
                throw new ArgumentException("Job title is required");

            // Check if username already exists
            if (employees.Any(e => e.UserName.Equals(employee.UserName, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Username already exists");

            // Set new ID
            int maxId = employees.Count > 0 ? employees.Max(e => e.EmployeeId) : 0;
            int newId = maxId + 1;
            employee.EmployeeId = newId++;
            employees.Add(employee);
        }
        public static void UpdateEmployee(Employees employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));           
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new ArgumentException("Employee name is required");
            if (string.IsNullOrWhiteSpace(employee.UserName))
                throw new ArgumentException("Username is required");
            if (string.IsNullOrWhiteSpace(employee.Password))
                throw new ArgumentException("Password is required");
            if (string.IsNullOrWhiteSpace(employee.JobTitle))
                throw new ArgumentException("Job title is required");           
            var existingEmployee = employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee == null)
                throw new ArgumentException($"Employee with ID {employee.EmployeeId} not found");

            if (employees.Any(e => e.EmployeeId != employee.EmployeeId &&
                               e.UserName.Equals(employee.UserName, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Username already exists");

            existingEmployee.Name = employee.Name;
            existingEmployee.UserName = employee.UserName;
            existingEmployee.Password = employee.Password;
            existingEmployee.JobTitle = employee.JobTitle;           
        }

        public static void DeleteEmployee(int employeeId)
        {
            var employeeToRemove = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
            }
        }
        public static Employees Login(string userName, string password) =>
            employees.FirstOrDefault(e => e.UserName == userName && e.Password == password);
    }
}
