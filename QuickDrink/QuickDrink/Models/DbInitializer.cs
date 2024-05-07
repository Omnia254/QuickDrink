using System;

namespace QuickDrink.Models
{
    public class DbInitializer
    {
        public static void Seed(QuickDrinkContext context)
        {
            
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Drinks.Any())
            {
                context.AddRange
                (
                    new Drink
                    {
                        Name = "Iced Coffee",
                        Price = 12.95M,
                        ShortDescription = "Refreshing cold coffee beverage.",
                        LongDescription = "Iced coffee is a chilled coffee beverage made from brewed coffee that is cooled down and served over ice. It is usually sweetened and flavored with milk or cream.",
                        Category = Categories["Cold"],
                        ImageUrl = "http://imgh.us/icedCoffeeL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/icedCoffeeS.jpg"
                    },
                    new Drink
                    {
                        Name = "Hot Chocolate",
                        Price = 10.95M,
                        ShortDescription = "Warm and comforting chocolate drink.",
                        LongDescription = "Hot chocolate, also known as hot cocoa or drinking chocolate, is a heated beverage consisting of shaved chocolate, melted chocolate or cocoa powder, heated milk or water, and usually a sweetener. It is typically enjoyed during colder weather as a comforting treat.",
                        Category = Categories["Hot"],
                        ImageUrl = "http://imgh.us/hotChocolateL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/hotChocolateS.jpg"
                    },
                    new Drink
                    {
                        Name = "Iced Tea",
                        Price = 8.95M,
                        ShortDescription = "Cool and refreshing tea served over ice.",
                        LongDescription = "Iced tea is a chilled tea beverage served over ice. It can be sweetened or unsweetened and flavored with lemon, mint, or other additions. It is a popular drink for staying cool during hot weather.",
                        Category = Categories["Cold"],
                        ImageUrl = "http://imgh.us/icedTeaL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/icedTeaS.jpg"
                    },
                    new Drink
                    {
                        Name = "Chai Latte",
                        Price = 9.95M,
                        ShortDescription = "Spiced tea blended with milk and sweetener.",
                        LongDescription = "Chai latte is a spiced tea beverage made by brewing black tea with a mixture of aromatic spices and herbs, such as cinnamon, cardamom, cloves, and ginger. It is then mixed with steamed milk and sweetened to taste.",
                        Category = Categories["Hot"],
                        ImageUrl = "http://imgh.us/chaiLatteL.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "http://imgh.us/chaiLatteS.jpg"
                    },
                    new Drink
                    {
                        Name = "Lemonade",
                        Price = 7.95M,
                        ShortDescription = "Refreshing citrus drink made with lemon juice.",
                        LongDescription = "Lemonade is a sweetened lemon-flavored beverage made from lemon juice, water, and sugar. It is typically served cold and is a popular thirst-quenching drink during hot weather.",
                        Category = Categories["Cold"],
                        ImageUrl = "http://imgh.us/lemonadeL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/lemonadeS.jpg"
                    },
                    new Drink
                    {
                        Name = "Hot Apple Cider",
                        Price = 8.95M,
                        ShortDescription = "Warm and spiced apple beverage.",
                        LongDescription = "Hot apple cider is a warm beverage made from apple cider or apple juice that is heated and spiced with cinnamon, cloves, nutmeg, and other spices. It is often enjoyed during the fall and winter months.",
                        Category = Categories["Hot"],
                        ImageUrl = "http://imgh.us/hotCiderL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/hotCiderS.jpg"
                    },
                    new Drink
                    {
                        Name = "Iced Lemon Tea",
                        Price = 8.95M,
                        ShortDescription = "Refreshing tea with a hint of lemon flavor, served over ice.",
                        LongDescription = "Iced lemon tea is a chilled tea beverage flavored with lemon juice and sweetened to taste. It is served over ice and is a popular choice for staying cool during hot weather.",
                        Category = Categories["Cold"],
                        ImageUrl = "http://imgh.us/icedLemonTeaL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/icedLemonTeaS.jpg"
                    },
                    new Drink
                    {
                        Name = "Hot Green Tea",
                        Price = 7.95M,
                        ShortDescription = "Warm and comforting green tea beverage.",
                        LongDescription = "Hot green tea is a heated beverage made from green tea leaves steeped in hot water. It is known for its light and refreshing flavor and is often enjoyed for its health benefits.",
                        Category = Categories["Hot"],
                        ImageUrl = "http://imgh.us/hotGreenTeaL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/hotGreenTeaS.jpg"
                    }

                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                       
                        new Category{CategoryName="Cold",Description="All Cold Drinks"},
                        new Category{CategoryName="Hot",Description="All Hot Drinks"}
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
