using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
{

    var configuration = builder.Configuration;
    var connectionString = configuration.GetConnectionString("sql_connection");
     options.UseSqlite(connectionString);

    //var version = new MySqlServerVersion(new Version(8, 0, 32));
    //options.UseMySql(connectionString, version);

});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();

var app = builder.Build();
SeedData.TestVerileriniDoldur(app);

app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();
