using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess;
using MovieLibraryWeb.Configuration;
using MovieLibraryWeb.Middlewares;
using mvc.Data.DataSeed;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIndentity();

builder.Services.AddAuthethicationAndAuthorization();

builder.Services.AddMyServices();
builder.Host.UseSerilog((ctx, lc) => lc
      .WriteTo.Console()
      .ReadFrom.Configuration(ctx.Configuration));


var app = builder.Build();

app.UseSerilogRequestLogging(config =>
{
    config.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000} ms";
});
app.GlobalExceptionHandling();

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
