using CulinaryCommand.Data;
using CulinaryCommand.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryCommand.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _ctx;

        public OrderService(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<List<OrderItem>> GetAllAsync()
            => await _ctx.OrderItems.ToListAsync();

        public async Task<OrderItem?> GetByIdAsync(int id)
            => await _ctx.OrderItems.FindAsync(id);

        public async Task AddAsync(OrderItem item)
        {
            _ctx.OrderItems.Add(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem item)
        {
            var existing = await _ctx.OrderItems.FindAsync(item.Id);
            if (existing == null) return;

            existing.Name        = item.Name;
            existing.LastOrdered = item.LastOrdered;
            existing.Level       = item.Level;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var it = await _ctx.OrderItems.FindAsync(id);
            if (it != null)
            {
                _ctx.OrderItems.Remove(it);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
