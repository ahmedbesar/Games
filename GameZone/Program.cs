using GameZone.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Custom Services

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCloudscribePagination();


builder.Services.AddScoped<ICategories, ClsCategories>();
builder.Services.AddScoped<IDevices, ClsDevices>();
builder.Services.AddScoped<IGames,ClsGames>();

#endregion
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameZoneDBContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
