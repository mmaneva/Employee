using Employees.Models.DataManager;
using Employees.Repository;
using Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employees.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IDataRepository<Employee> _dataRepository;

        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = _dataRepository.Get(id);

            if (employee == null)
            {
                return NotFound("Employee was not found");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Emp[loyee is null");
            }

            _dataRepository.Post(employee);

            return Ok(employee);

   
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }

            Employee dbEmployee = _dataRepository.Get(id);
            if (dbEmployee == null)
            {
                return NotFound("Employee was not found");
            }

            _dataRepository.Put(dbEmployee, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee dbEmployee = _dataRepository.Get(id);

            if(dbEmployee == null)
            {
                return NotFound("Employee not exist");
            }

            _dataRepository.Delete(dbEmployee);
            return NoContent();
        }
    }
}
