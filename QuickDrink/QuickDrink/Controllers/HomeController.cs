using Microsoft.AspNetCore.Mvc;
using QuickDrink.EntityManagement.Interfaces;
using QuickDrink.Models;
using QuickDrink.ViewModels;
using System.Diagnostics;

namespace QuickDrink.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(homeViewModel);
        }
    }
}
