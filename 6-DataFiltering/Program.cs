using _6_DataFiltering.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlite(connection));
builder.Services.AddMvc();
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
