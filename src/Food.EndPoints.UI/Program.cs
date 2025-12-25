using Food.Infra.Data.Db.SqlServer.Database;
using Food.Infra.Data.Db.SqlServer.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppFoodDbContext>(optionsBuilder => 
    optionsBuilder.UseSqlServer(
        "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Maktab_Food_Db; Integrated Security=True;"));

builder.Services.AddDbContext<UsersDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(
        "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Maktab_Food_Db; Integrated Security=True;"));


// Identity Configuration
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(option =>
        {
            // Password Settings
            option.Password.RequireDigit = false;
            option.Password.RequireLowercase = true;
            option.Password.RequireUppercase = true;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequiredLength = 7;

            // Lockout Settings
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            option.Lockout.MaxFailedAccessAttempts = 3;

            // SignIn Settings
            option.SignIn.RequireConfirmedAccount = false;
            option.SignIn.RequireConfirmedEmail = false;
            option.SignIn.RequireConfirmedPhoneNumber = false;

            // Uer Settings
            option.User.RequireUniqueEmail = true;
            // option.User.AllowedUserNameCharacters="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        })
    .AddEntityFrameworkStores<UsersDbContext>()
    .AddDefaultTokenProviders();

// Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Account/Index";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(24 * 7);
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
