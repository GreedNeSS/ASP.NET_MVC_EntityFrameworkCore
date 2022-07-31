using Microsoft.EntityFrameworkCore;
using _5_SortTagHelper.Models;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlite(connection));
builder.Services.AddMvc();
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();