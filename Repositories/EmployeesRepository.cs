using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public void AddEmployee(Employees employee)
        {
            EmployeesDAO.AddEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            EmployeesDAO.DeleteEmployee(employeeId);
        }

        public Employees GetEmployeeById(int employeeId)
        {
            return EmployeesDAO.GetEmployeeById(employeeId);
        }

        public List<Employees> GetEmployees()
        {
            return EmployeesDAO.GetAllEmployees();
        }

        public Employees Login(string userName, string password)
        {
            return EmployeesDAO.Login(userName, password);
        }

        public void UpdateEmployee(Employees employee)
        {
            EmployeesDAO.UpdateEmployee(employee);
        }
    }
}
