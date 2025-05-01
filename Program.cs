using CulinaryCommand.Data;
using CulinaryCommand.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 1) Configure EF Core to use SQLite
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 2) Add ASP.NET Core Identity
builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        // you can tweak password, lockout, etc. here if desired
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 3) Add Razor Pages and Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 4) Register your application services
builder.Services.AddScoped<IPrepService, PrepService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// 5) Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 6) Enable authentication & authorization
app.UseAuthentication();
app.UseAuthorization();

// 7) Map endpoints
app.MapRazorPages();              // for Identity UI
app.MapBlazorHub();               // for Blazor Server
app.MapFallbackToPage("/_Host");  // for all other routes

app.Run();
