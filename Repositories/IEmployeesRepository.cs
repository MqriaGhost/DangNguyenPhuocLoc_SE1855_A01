using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEmployeesRepository
    {
        List<Employees> GetEmployees();
        Employees GetEmployeeById(int employeeId);
        void AddEmployee(Employees employee);
        void UpdateEmployee(Employees employee);
        void DeleteEmployee(int employeeId);
        Employees Login(string userName, string password);
    }
}
