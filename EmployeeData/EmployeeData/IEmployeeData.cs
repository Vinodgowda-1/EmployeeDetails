using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataWebApi.Models;

namespace EmployeeDataWebApi.EmployeeData
{
   public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Guid id);

        Employee EditEmployee(Employee employee);
    }
}
