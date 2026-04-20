
using Microsoft.EntityFrameworkCore;
using Practice_assignment.Data;
using Practice_assignment.Patterns.Factory;
using Practice_assignment.Patterns.Observer;
using Practice_assignment.Patterns.Repository;
using Practice_assignment.Services;


var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories: Repository Pattern
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();

// Factories : Factory Pattern
builder.Services.AddSingleton<IContractFactory, ContractFactory>();

// Observers: Observer Pattern
builder.Services.AddScoped<IContractObserver, AuditLogObserver>();

// Business Logic Services 
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IContractObserver, AuditLogObserver>();
builder.Services.AddScoped<IContractObserver, ExpiryNotificationObserver>(); 

// HTTP Client for Currency API 
builder.Services.AddHttpClient<ICurrencyService, CurrencyService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(10);
});

//  MVC 
builder.Services.AddControllersWithViews();

var app = builder.Build();

//  Middleware pipeline 
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

// Auto migrate on startup 
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
db.Database.Migrate();

app.Run();

// Required for integration test WebApplicationFactory
public partial class Program { }