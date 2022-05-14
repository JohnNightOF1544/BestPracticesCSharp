using BestPracticesCsharp.Models;

namespace BestPracticesCsharp.Service
{
    public interface IEmployees
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid id);
    }
}
