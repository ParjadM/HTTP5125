using Cumulative1.Controllers;
using Cumulative1.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseMySql(
        "server=localhost;database=schooldb;user=root;password=;",
        new MySqlServerVersion(new Version(10, 4, 32)) 
    ));


builder.Services.AddTransient<TeacherAPIController>();
builder.Services.AddScoped<CourseAPIController>(); 
builder.Services.AddScoped<StudentAPIController>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
