using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_ClassLibrary
{
    public class MenuRepository
        //CRUD
    {
        protected readonly List<MenuItems> _menu = new List<MenuItems>();

        public bool AddMealToDirectory(MenuItems menu)
        {
            int startingMenu = _menu.Count;
            _menu.Add(menu);
            bool wasAdded = (_menu.Count > startingMenu) ? true : false;
            return wasAdded;
        }

        public List<MenuItems> GetFullMenu()
        {
            return _menu;
        }

        public MenuItems GetMealByName(string mealName)
        {
            foreach (MenuItems itemInfo in _menu)
            {
                if (itemInfo.MealName.ToLower() == mealName.ToLower())
                {
                    return itemInfo;
                }
            }
            return null;
        }

        public MenuItems GetMealByNumber(int mealNumber)
        {
            foreach (MenuItems itemInfo in _menu)
            {
                if (mealNumber == itemInfo.MealNumber )
                {
                    return itemInfo;
                }
            }
            return null; 
        }

        public bool DeleteExisitingMeal(MenuItems exisitingMeal)
        {
            bool deleteMeal = _menu.Remove(exisitingMeal);
            return deleteMeal;
        }
    }
}
