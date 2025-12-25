using Food.Infra.Data.Db.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using UI_MVC.Models.Database;
using UI_MVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppPeopleDbContext>(optionsBuilder =>
	optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Maktab_PeopleDb; Integrated Security=True;"));

builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // app.UseSwaggerUI(options =>
    // {
    //     options.SwaggerEndpoint("/openapi/v1.json", "Maktab135 API v1");
    // });
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();
app.MapControllerRoute(
	"default",
	"api/v{version:apiVersion}/{controller=Home}/{action=Index}/{id?}");

app.Run();
