using Microsoft.EntityFrameworkCore;
using Cumulative1.Model; 
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29)); 

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=TeacherPage}/{action=List}/{id?}"); 
});

app.MapControllers(); 

app.Run();