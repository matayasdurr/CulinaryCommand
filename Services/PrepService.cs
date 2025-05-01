using CulinaryCommand.Data;
using CulinaryCommand.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryCommand.Services
{
    public class PrepService : IPrepService
    {
        private readonly ApplicationDbContext _context;

        public PrepService(ApplicationDbContext context)
            => _context = context;

        public async Task<List<PrepItem>> GetAllAsync(DateTime date)
        {
            // If you add a Date field to PrepItem, filter by it.
            return await _context.PrepItems.ToListAsync();
        }

        public async Task<PrepItem> GetByIdAsync(int id)
            => await _context.PrepItems.FindAsync(id);

        public async Task AddAsync(PrepItem item)
        {
            _context.PrepItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PrepItem item)
        {
            // 1) Fetch the already‐tracked entity
            var existing = await _context.PrepItems.FindAsync(item.Id);
            if (existing == null)
                return;

            // 2) Copy over the edited values
            existing.Name       = item.Name;
            existing.Category   = item.Category;
            existing.Par        = item.Par;
            existing.Count      = item.Count;
            existing.Prep       = item.Prep;
            existing.AssignedTo = item.AssignedTo;
            existing.Status     = item.Status;

            // 3) Save—EF Core already knows this is Modified
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.PrepItems.FindAsync(id);
            if (item != null)
            {
                _context.PrepItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
