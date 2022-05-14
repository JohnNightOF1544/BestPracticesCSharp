using BestPracticesCsharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestPracticesCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly BestPracticesContext _db;

        public EmpController(BestPracticesContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<Employee>>> GetAll()
        {
            List<Employee> emp = await _db.Employees
                .FromSqlInterpolated<Employee>($"Select * FROM Employees")
                .ToListAsync();
            return Ok(new { success = true, message = "Here are the list of employee", data = emp });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IQueryable<Employee>>> GetById(string id)
        {
            //IQueryable<Employee> list = from dataInRows in _db.Employees where dataInRows.SysId == id select dataInRows;

            List<Employee> listOfEmployees = await _db.Employees
                .FromSqlInterpolated($"Select * From Employees Where Employees.Sys_Id = {id}")
                .ToListAsync();
            return Ok(new { success = true, message = "Here are the list of employee", data = listOfEmployees });
        }

        [HttpPost]
        public async Task<ActionResult<IQueryable<Employee>>> AddEmployee(Employee employee)
        {
            if (employee is null)
            {
                return BadRequest(new { success = false, message = "Please input all fields" });
            }
            if (employee is not null)
            {
                _db.Employees.Add(employee);
                await _db.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = employee.SysId }, employee);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            Employee? updateEmployee = await _db.Employees.FindAsync(id);

            if (updateEmployee == null)
            {
                return BadRequest(new { success = false, message = "Error while deleting." });
            }
            _db.Employees.Remove(updateEmployee);
            await _db.SaveChangesAsync();
            return Ok(new { success = true, message = "Deleted Successfully" });
        }
    }
}
