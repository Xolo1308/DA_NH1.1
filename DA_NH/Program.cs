using Microsoft.EntityFrameworkCore;
using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using DA_NH.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DemoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //options.Locout.AllowedForNewUsers = true; // Cho phép khóa tài khoản
});
// Add services to the container.
builder.Services.AddScoped<LoginAttemptService>();
builder.Services.AddMemoryCache();

builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
// admin

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// user
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// admin

app.Run();