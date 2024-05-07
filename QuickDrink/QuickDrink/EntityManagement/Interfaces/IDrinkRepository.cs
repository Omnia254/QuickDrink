using QuickDrink.Models;

namespace QuickDrink.EntityManagement.Interfaces
{
    public interface IDrinkRepository
    {

        IEnumerable<Drink> Drinks { get; }
        IEnumerable<Drink> PreferredDrinks { get; }
        Drink GetDrinkById(int drinkId);
    }
}
