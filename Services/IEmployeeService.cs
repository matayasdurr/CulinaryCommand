using CulinaryCommand.Models;
namespace CulinaryCommand.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?>   GetByIdAsync(int id);
        Task AddAsync(Employee e);
        Task UpdateAsync(Employee e);
        Task DeleteAsync(int id);
    }
}
