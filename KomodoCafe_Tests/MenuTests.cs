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

        private MenuRepository _repo;
        private MenuItems _menuItem;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _menuItem = new MenuItems("Chicken Meal", "Very Tasty", "Chicken", 4.99m, 10);
            _repo.AddMealToDirectory(_menuItem);
        }

        [TestMethod]
        public void GetMealByName_ShouldReturnCorrectMeal()
        {
            MenuItems menuItem = _repo.GetMealByName("Chicken Meal");

            Assert.AreEqual(_menuItem, menuItem);
        }

        [TestMethod]
        public void GetMealByNumber_ShouldReturnCorrectNumber()
        {
            MenuItems menuItems = _repo.GetMealByNumber(10);

            Assert.AreEqual(_menuItem, menuItems);
        }

        [TestMethod]
        public void DeleteExistingMeal_ShouldReturnTrue()
        {
            MenuItems menuItem = _repo.GetMealByName("Chicken Meal");

            bool removeItem = _repo.DeleteExisitingMeal(menuItem);

            Assert.IsTrue(removeItem);
        }


    }
}
