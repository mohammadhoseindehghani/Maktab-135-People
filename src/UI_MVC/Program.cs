using Framework.Maktab.Web;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UI_MVC.Middlwares;
using UI_MVC.Models.Database;
using UI_MVC.Services;
using Microsoft.AspNetCore.Identity;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
var connectionString =
    "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Maktab_PeopleDb; Integrated Security=True;";

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .WriteTo.Console()
//    .CreateLogger();

builder.Services.AddMyServices();


builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});



builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IRealNumbers, RealNumbers>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<ICalculator, Calculator3>();
}
else
{
    builder.Services.AddScoped<Calculator2, Calculator2>();
}

builder.Services.AddDbContext<AppPeopleDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Maktab_PeopleDb; Integrated Security=True;"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppPeopleDbContext>();





// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseMiddlewares();

app.UseMiddleware<RequestLoggingMiddleware>();
//app.UseMiddleware<LoggingMiddleware>();
//app.UseMiddleware<IpCheckerMiddleware>();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();


app.Run();
