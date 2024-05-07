using QuickDrink.Models;

namespace QuickDrink.EntityManagement.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
