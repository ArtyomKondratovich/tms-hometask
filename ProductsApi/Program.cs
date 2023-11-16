using ProductsApi.DataBase;
using ProductsApi.Exstensions;
using ProductsApi.Services;

var builder = WebApplication.CreateBuilder(args);

var loggerFactory = LoggerFactory.Create(
    loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole());

var dbPath = Path.Combine(Directory.GetCurrentDirectory(), builder.Configuration["dbPath"]);

IDataBase db = new DataBase(dbPath, loggerFactory.CreateLogger<DataBase>());

builder.Services.AddSingleton<IStoragesService>(
    new StoragesService(loggerFactory.CreateLogger<StoragesService>(), db));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// extension for my exceptionMiddleware


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
    pattern: "{controller=Storages}/{action=GetAllProducts}/{id?}");

app.Run();
