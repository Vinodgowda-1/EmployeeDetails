using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataWebApi.EmployeeData;
using EmployeeDataWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDataWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok (_employeeData.GetEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult GetEmployee(Employee employee)
        {
             _employeeData.AddEmployee(employee);
            return Ok(employee);
        }


        [HttpDelete]  
        public IActionResult DeleteEmployee(Guid id)
        {
           
            var employee = _employeeData.GetEmployee(id);
            _employeeData.DeleteEmployee(employee);
            return Ok(employee);
        }
        [HttpPatch]
        public IActionResult EditEmployee(Guid id,Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            employee.Id = existingEmployee.Id;
            _employeeData.EditEmployee(employee);
            return Ok(employee);
        }
    }
}
