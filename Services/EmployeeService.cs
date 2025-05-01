using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryCommand.Data;
using CulinaryCommand.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryCommand.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddAsync(Employee e)
        {
            _context.Employees.Add(e);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee e)
        {
            var existing = await _context.Employees.FindAsync(e.Id);
            if (existing == null) 
                return;

            existing.Name     = e.Name;
            existing.Role     = e.Role;
            existing.Email    = e.Email;
            existing.IsActive = e.IsActive;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
