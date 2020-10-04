using System;
using System.Collections.Generic;
using KomodoCafe_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void AddMealToMenu_ShouldGetCorrectBoolean()
        {
            MenuItems meal = new MenuItems();
            MenuRepository repo = new MenuRepository();

            bool addMeal = repo.AddMealToDirectory(meal);

            Assert.IsTrue(addMeal);
        }

        [TestMethod]
        public void PrintMenu_ShouldPrintFullMenu()
        {
            MenuItems meal = new MenuItems();
            MenuRepository repo = new MenuRepository();
            repo.AddMealToDirectory(meal);

            List<MenuItems> fullMenu = repo.GetFullMenu();

            bool menuHasMeals = fullMenu.Contains(meal);
            Assert.IsTrue(menuHasMeals);
        }
    }
}
