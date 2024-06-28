using Data;
using Laboratorium3_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium3_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Retrieve the connection string from configuration
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
                
           
            // Add services to the container
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            // Register AppDbContext with the connection string
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

            // Register HttpClient
            builder.Services.AddHttpClient();

            // Configure Identity services
            builder.Services.AddDefaultIdentity<IdentityUser>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<AppDbContext>();

            // Register custom services
            builder.Services.AddTransient<IReservationService, ReservationService>();
            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();

            // Register caching and session services
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

            var app = builder.Build();

            // Initialize the database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Middleware for last visit cookie
            app.UseMiddleware<LastVisitCookie>();

            // Authentication and Authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            // Map Razor pages and default routes
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
