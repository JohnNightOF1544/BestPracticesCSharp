using BestPracticesCsharp.Models;
using Microsoft.EntityFrameworkCore;

namespace BestPracticesCsharp.Service
{
    public class EmployeeRepository : IEmployees
    {
         private readonly BestPracticesContext _context;

        public EmployeeRepository(BestPracticesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid id)
        {

            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(paramName: nameof(id));
            }
            List<Employee> listOfEmployees = await _context.Employees
                .FromSqlInterpolated($"Select * From Employees Where Employees.Sys_Id = {id}")
                .ToListAsync();
            return listOfEmployees;
        }


    }
}
