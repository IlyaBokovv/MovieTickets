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

var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseMiddleware<GlobalErrorHandlingMiddleware>();

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
