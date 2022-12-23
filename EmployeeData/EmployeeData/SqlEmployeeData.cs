using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataWebApi.Models;

namespace EmployeeDataWebApi.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Guid id)
        {
            var employee = GetEmployee(id);

            if(employee == null)
            {
                throw new Exception("Not found");          
            }
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.Id);
            existingEmployee.Id = employee.Id;
            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            existingEmployee.JobTitle = employee.JobTitle;  
            existingEmployee.Department = employee.Department;
            existingEmployee.DateOfJoining = employee.DateOfJoining;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Email = employee.Email;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            _employeeContext.Employees.Update(existingEmployee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
           var employee=  _employeeContext.Employees.Find(id);
            return employee;
           // return _employeeContext.Employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}