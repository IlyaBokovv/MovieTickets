using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess;
using MovieLibraryWeb.Configuration;
using MovieLibraryWeb.Middlewares;
using mvc.Data.DataSeed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIndentity();

builder.Services.AddAuthethicationAndAuthorization();

builder.Services.AddMyServices();

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
await DataSeeding.SeedAsync(app);
await DataSeeding.SeedUsersAndRolesAsync(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
