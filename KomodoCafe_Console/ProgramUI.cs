using KomodoCafe_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continuetoRun = true;
            while (continuetoRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you would like to select: \n" +
                    "1) Show Full Menu \n" +
                    "2) Show Meal Information \n" +
                    "3) Add New Meal \n" +
                    "4) Remove Old Meal \n" +
                    "5) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case 
                        "1":
                        GetFullMenu();
                        break;
                    case
                        "2":
                        ShowMenuItemInfoByName();
                        break;
                    case
                        "3":
                        AddMealToMenu();
                        break;
                    case
                        "4":
                        DeleteMealFromMenu();
                        break;
                    case
                        "5":
                        continuetoRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number option. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayMenuItemName(MenuItems item)
        {
            Console.WriteLine($"{item.MealNumber}: {item.MealName} \n" +
                $"--------------------------");
        }
        private void DisplaySingularMenuItemInformation(MenuItems item)
        {
            if (item != null)
            {
                Console.WriteLine($"{item.MealNumber}: {item.MealName} \n" +
                                $"Description: {item.MealDescription} \n" +
                                $"Ingredients: {item.Ingredients} \n" +
                                $"Price (USD): {item.Price} \n");
            }
            else
            {
                Console.WriteLine("Please enter the meal number");
                Console.ReadKey();
            }
        }
        private void ShowMenuItemInfoByName()
        {
            Console.Clear();
            Console.WriteLine("Please enter a meal number: \n");
            GetFullMenuNoPressEnter();
            int itemNumber = int.Parse(Console.ReadLine());
            MenuItems chosenMeal = _menuRepo.GetMealByNumber(itemNumber);
            Console.Clear();
            DisplaySingularMenuItemInformation(chosenMeal);
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
        private void GetFullMenu()
        {
            Console.Clear();
            List<MenuItems> fullMenu = _menuRepo.GetFullMenu();
            foreach(MenuItems menuItem in fullMenu)
            {
                DisplayMenuItemName(menuItem);
            }
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        private void GetFullMenuNoPressEnter()
        {
            List<MenuItems> fullMenu = _menuRepo.GetFullMenu();
            foreach (MenuItems menuItem in fullMenu)
            {
                DisplayMenuItemName(menuItem);
            }
        }

        private void AddMealToMenu()
        {
            MenuItems meal = new MenuItems();
            Console.Clear();
            Console.WriteLine("Enter the name of the meal");
            meal.MealName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Enter a description for {meal.MealName}");
            meal.MealDescription = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Enter the ingredient list for {meal.MealName}");
            meal.Ingredients = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Enter the price for {meal.MealName}");
            string mealPriceString = Console.ReadLine();
            
            decimal mealPriceDecimal = decimal.Parse(mealPriceString);
            meal.Price = mealPriceDecimal;

            Console.Clear();
            Console.WriteLine($"Enter the number for {meal.MealName}");
            int id = int.Parse(Console.ReadLine());
            meal.MealNumber = id;

            _menuRepo.AddMealToDirectory(meal);
            Console.Clear();
            Console.WriteLine("Meal Successfully Added! Press any key to return to the main menu");
            Console.ReadKey();
        }
        private void DeleteMealFromMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you want to remove. \n");
            List<MenuItems> menuList = _menuRepo.GetFullMenu();
            int count = 0;
            foreach(var meal in menuList)
            {
                count++;
                Console.WriteLine($"{meal.MealNumber} {meal.MealName}");
            }
            int targetMealNumber = int.Parse(Console.ReadLine());
            int correctIndex = targetMealNumber - 1;
            if( correctIndex >= 0 && correctIndex < menuList.Count)
            {
                MenuItems desiredMeal = menuList[correctIndex];
                if (_menuRepo.DeleteExisitingMeal(desiredMeal))
                {
                    Console.Clear();
                    Console.WriteLine($"{desiredMeal.MealName} has been removed. \n");
                }
                else
                {
                    Console.WriteLine("Could not remove meal.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please choose a valid option \n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedMenu()
        {
            var hamburgerMeal = new MenuItems("Hamburger Meal", "Exquisite hamburger with fries and a soft - drink of your choosing.", "Hamburger Patty, Lettuce, Tomato, American Cheese, Pickles, Hamburger Bun and French Fries", 4.99m, 1);
            var chickenNuggetMeal = new MenuItems("Chicken Nugget Meal", "Top tier chicken nuggets with fries and a soft-drink of your choosing.", "Chicken nuggets and French Fries", 3.99m, 2);
            var fishAndChipsMeal = new MenuItems("Fish and Chips Meal", "Some of the best fish you can find in the middle of the USA, nothing fishy here other than how good it tastes!  Comes with fries and a soft-drink.", "Wild Cod Fillet and Fries", 6.99m, 3);
            var grilledCheeseMeal = new MenuItems("Grilled Cheese Meal", "A fan favorite, the grilled cheese.  No sides needed, trust me.", "Colby Jack Cheese, Wheat Bread, Butter", 2.99m, 4);

            _menuRepo.AddMealToDirectory(hamburgerMeal);
            _menuRepo.AddMealToDirectory(chickenNuggetMeal);
            _menuRepo.AddMealToDirectory(fishAndChipsMeal);
            _menuRepo.AddMealToDirectory(grilledCheeseMeal);
        }
    }
}
