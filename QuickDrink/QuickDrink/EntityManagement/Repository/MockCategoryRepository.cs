using QuickDrink.EntityManagement.Interfaces;
using QuickDrink.Models;

namespace QuickDrink.EntityManagement.Repository
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Cold",Description="All Cold Drinks"},
                    new Category{CategoryName="Hot",Description="All Hot Drinks"}
                };
            }
        }
    }
}
