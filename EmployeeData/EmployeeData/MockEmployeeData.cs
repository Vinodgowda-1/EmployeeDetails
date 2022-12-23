using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataWebApi.Models;

namespace EmployeeDataWebApi.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id=Guid.NewGuid(),Name="Vinod",Age=22,JobTitle="Full stack developer",Department="Software",DateOfJoining="01/12/2022"},
            new Employee(){Id=Guid.NewGuid(),Name="Acchu",Age=25,JobTitle="Web developer",Department="Software",DateOfJoining="15/10/2022"},
            new Employee(){Id=Guid.NewGuid(),Name="Ram",Age=30,JobTitle="RF Engineer",Department="RF",DateOfJoining="11/11/2022"},

        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
           
            employees.Remove(employee);            
        }

        public void DeleteEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee EditEmployee(Employee employee)
        {

            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            existingEmployee.JobTitle = employee.JobTitle;
            existingEmployee.Department = employee.Department;
            existingEmployee.DateOfJoining = employee.DateOfJoining;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Email = employee.Email;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;

        }
    }
}
