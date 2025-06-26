using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository iemployeeRepository;
        public EmployeesService()
        {
            iemployeeRepository = new EmployeesRepository(); // Replace with actual repository instantiation
        }

        public void AddEmployee(Employees employee)
        {
            iemployeeRepository.AddEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            iemployeeRepository.DeleteEmployee(employeeId);
        }

        public Employees GetEmployeeById(int employeeId)
        {
            return iemployeeRepository.GetEmployeeById(employeeId);
        }

        public List<Employees> GetEmployees()
        {
            return iemployeeRepository.GetEmployees();
        }

        public Employees Login(string userName, string password)
        {
            return iemployeeRepository.Login(userName, password);
        }

        public void UpdateEmployee(Employees employee)
        {
            iemployeeRepository.UpdateEmployee(employee);
        }
    }
}
