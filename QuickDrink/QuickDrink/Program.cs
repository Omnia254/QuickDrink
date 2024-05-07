using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuickDrink.EntityManagement.Interfaces;
using QuickDrink.EntityManagement.Repository;
using QuickDrink.Models;

namespace QuickDrink
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a builder for configuring the application services and middleware pipeline
            var builder = WebApplication.CreateBuilder(args);

            // Add session support
            builder.Services.AddSession();

            // Register services required by the application
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sp => ShoppingCart.GetCart(sp));

            // Add controllers and views support
            builder.Services.AddControllersWithViews();

            // Configure the database context
            builder.Services.AddDbContext<QuickDrinkContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Build the application
            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                // Use error handling middleware in non-development environments
                app.UseExceptionHandler("/Home/Error");
            }

            // Serve static files like CSS, JavaScript, and images
            app.UseStaticFiles();

            // Enable routing for MVC controllers
            app.UseRouting();

            // Add authorization middleware
            app.UseAuthorization();

            // Enable session state
            app.UseSession();

            // Map the custom routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "drinkdetails",
                    pattern: "Drink/Details/{drinkId?}",
                    defaults: new { controller = "Drink", action = "Details" });

                endpoints.MapControllerRoute(
                    name: "categoryfilter",
                    pattern: "Drink/{action}/{category?}",
                    defaults: new { controller = "Drink", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Seed the database with initial data
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<QuickDrinkContext>();
                DbInitializer.Seed(context);
            }

            // Run the application
            app.Run();
        }
    }
}
