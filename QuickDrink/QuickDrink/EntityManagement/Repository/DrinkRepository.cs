using Microsoft.EntityFrameworkCore;
using QuickDrink.EntityManagement.Interfaces;
using QuickDrink.Models;

namespace QuickDrink.EntityManagement.Repository
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly QuickDrinkContext _context;
        public DrinkRepository(QuickDrinkContext quickDrinkContext) 
        { 
            _context = quickDrinkContext;

        }
        public IEnumerable<Drink> Drinks => _context.Drinks.Include(c=>c.Category);

        public IEnumerable<Drink> PreferredDrinks => _context.Drinks.Where(p=>p.IsPreferredDrink).Include(c=>c.Category);

        public Drink GetDrinkById(int drinkId) => _context.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
    }
}
