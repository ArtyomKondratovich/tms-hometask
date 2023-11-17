using Microsoft.EntityFrameworkCore;
using ProductsApi.DataBase;
using ProductsApi.Exstensions;
using ProductsApi.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(builder =>
{
    builder.AddConsole(); // Add console logging provider
    builder.AddDebug(); // Add debug logging provider
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();

var options = optionsBuilder
        .UseSqlServer(connectionString)
        .Options;

var dbContext = new MyDbContext(options);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IStoragesService>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<StoragesService>>();

    return new StoragesService(dbContext, logger);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseExceptionMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Storages}/{action=GetAllStorages}/{id?}");

app.Run();
