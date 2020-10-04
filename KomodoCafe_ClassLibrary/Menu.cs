using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_ClassLibrary
{
    public class MenuItems
    {
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }
        public int MealNumber { get; set; }

        public MenuItems() { }

        public MenuItems(string mealName, string mealDescription, string ingredients, decimal price, int mealNumber)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
            MealNumber = mealNumber;
        }
    }
}
