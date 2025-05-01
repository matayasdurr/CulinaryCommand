using CulinaryCommand.Models;

namespace CulinaryCommand.Services
{
    public interface IPrepService
    {
        Task<List<PrepItem>> GetAllAsync(DateTime date);
        Task<PrepItem> GetByIdAsync(int id);
        Task AddAsync(PrepItem item);
        Task UpdateAsync(PrepItem item);
        Task DeleteAsync(int id);
    }
}
