using QuickDrink.EntityManagement.Interfaces;
using QuickDrink.Models;

namespace QuickDrink.EntityManagement.Repository
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuickDrinkContext _context;
        public CategoryRepository(QuickDrinkContext quickDrinkContext)
        {
            _context = quickDrinkContext;

        }
        public IEnumerable<Category> Categories =>  _context.Categories;
    }
}
