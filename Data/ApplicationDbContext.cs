using Microsoft.AspNetCore.Identity;             
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CulinaryCommand.Models;

namespace CulinaryCommand.Data
{
  public class ApplicationDbContext : IdentityDbContext<IdentityUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
      : base(opts) { }

    public DbSet<PrepItem> PrepItems   { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Employee>  Employees  { get; set; }
  }
}
