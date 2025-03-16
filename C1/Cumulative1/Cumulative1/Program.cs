using Cumulative1.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register SchoolDbContext with MySQL connection string
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseMySql(
        "server=localhost;database=schooldb;user=root;password=;",
        new MySqlServerVersion(new Version(10, 4, 32)) // MariaDB version
    ));

// Register TeacherAPIController
builder.Services.AddTransient<TeacherAPIController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
