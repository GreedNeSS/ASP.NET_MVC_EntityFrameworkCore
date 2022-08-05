using _10_SortFilterPaginationTagHelper.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
string connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlite(connection));
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
