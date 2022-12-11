using PetShopApplication.Data;
using Microsoft.EntityFrameworkCore;
using PetShopApplication.Reposotories;
using PetShopApplication.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepository, MyRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite("Data Source=c:\\temp\\PetShopDB.db"));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();
app.Run();





