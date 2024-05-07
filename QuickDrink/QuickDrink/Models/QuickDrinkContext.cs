using Microsoft.EntityFrameworkCore;


namespace QuickDrink.Models
{
    public class QuickDrinkContext : DbContext
    {

        public QuickDrinkContext() { }
        public QuickDrinkContext(DbContextOptions<QuickDrinkContext> options) : base(options)
        {

        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }
    
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
