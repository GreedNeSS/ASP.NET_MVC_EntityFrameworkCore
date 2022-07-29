using _2_AddingAndDisplayingData.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

string connection = builder.Configuration.GetConnectionString("DefaultConnection"); 
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection));
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
