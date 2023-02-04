using Lab_Day02.Models;
using Lab_Day02.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MVC_DbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
});

builder.Services.AddSession(options =>
options.IdleTimeout = TimeSpan.FromDays(1));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MVC_DbContext>();

builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireDigit = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequiredLength = 5;
    opts.User.RequireUniqueEmail = true;
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
