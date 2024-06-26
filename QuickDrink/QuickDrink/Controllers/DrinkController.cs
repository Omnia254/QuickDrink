﻿using Microsoft.AspNetCore.Mvc;
using QuickDrink.EntityManagement.Interfaces;
using QuickDrink.Models;
using QuickDrink.ViewModels;

namespace QuickDrink.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Hot", _category, StringComparison.OrdinalIgnoreCase))
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Hot")).OrderBy(p => p.Name);
                else
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Cold")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            });


        }
    }
}
