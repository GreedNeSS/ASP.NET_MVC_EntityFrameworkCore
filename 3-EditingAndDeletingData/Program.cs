using Microsoft.EntityFrameworkCore;
using _3_EditingAndDeletingData.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection));

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
