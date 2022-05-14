using BestPracticesCsharp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticesCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees _employees;

        public EmployeesController(IEmployees employees)
        {
            _employees = employees ?? throw new ArgumentNullException(paramName: nameof(employees));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees(Guid id)
        {
            var empEntity = await _employees.GetEmployeesAsync(id);
            if (empEntity == null)
            {
                return NotFound();
            }
            return Ok(new { success = true, message = "Here are the list of employee", data = empEntity });
        }








    }
}
