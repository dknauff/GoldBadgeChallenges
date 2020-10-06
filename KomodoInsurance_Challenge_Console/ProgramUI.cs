using KomodoInsurance_Challenge_ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KomodoInsurance_Challenge
{
    class ProgramUI
    {
        private readonly BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedBadges();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please select an option: \n" +
                    "1) Add a badge \n" +
                    "2) Edit a badge \n" +
                    "3) List all badges \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        Console.Clear();
                        ListAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number (1-4)");
                        break;
                }
            }
        }

        private void AddABadge()
        {
            Badge newBadge = new Badge();

            Console.Clear();
            Console.WriteLine("What is the number on the badge?");
            string badgeIDInput = Console.ReadLine();
            newBadge.BadgeID = Int32.Parse(badgeIDInput);

            bool moreDoors = true;
            while (moreDoors == true)
            {
                Console.Clear();
                Console.WriteLine($"List a door {badgeIDInput} needs access to:");
                string badgeDoorInput = Console.ReadLine();
                newBadge.DoorAccess.Add(badgeDoorInput);

                Console.WriteLine("Any other doors(y/n)?");
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "y")
                {
                    continue;
                }
                else
                {
                    _badgeRepository.CreateNewBadge(newBadge.BadgeID, newBadge.DoorAccess);
                    moreDoors = false;
                }
            }
        }

        private void EditABadge()
        {
            Badge oldBadge = new Badge();
            Dictionary<int, List<string>> dictionary = _badgeRepository.GetAllBadges();

            bool runBadgeMenu = true;
            while (runBadgeMenu == true)
            {
                Console.Clear();
                Console.WriteLine("What is the badge number you wish to update? \n");
                ListAllBadgesToEdit();
                string userInput = Console.ReadLine();
                int badgeIDInt = Int32.Parse(userInput);
                if (dictionary.ContainsKey(badgeIDInt))
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to do? \n" +
                        "1) Add a door \n" +
                        "2) Remove a door \n" +
                        "3) Return to main menu");
                    string menuChoice = Console.ReadLine();
                    switch (menuChoice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("List a door this badge needs access to:");
                            string badgeDoorInput = Console.ReadLine();
                            oldBadge.DoorAccess.Add(badgeDoorInput);
                            Console.Clear();
                            Console.WriteLine("So, editing the door access was the only thing I wasn't able to get to work in time, so for now you will receive this message instead of what you actually wanted.  I will give it another shot in the future. =)\n" +
                                "Press any key to continue...");
                            Console.ReadKey();

                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("What door do you wish to remove?");
                            string removeDoor = Console.ReadLine();
                            oldBadge.DoorAccess.Remove(removeDoor);
                            Console.Clear();
                            Console.WriteLine("So, editing the door access was the only thing I wasn't able to get to work in time, so for now you will receive this message instead of what you actually wanted.  I will give it another shot in the future. =)\n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            break;
                        case "3":
                            runBadgeMenu = false;
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option (1-3)");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please select an existing badge. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    runBadgeMenu = false;
                }
            }
        }

        private void ListAllBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepository.GetAllBadges();

            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine($"----------------- \n" +
                    $"Badge Number: \n" +
                    $"{ badge.Key} \n" +
                    $"Accessible Doors:");

                foreach (string value in badge.Value)
                {
                    Console.WriteLine($"{value}");
                }
            }
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }

        private void ListAllBadgesToEdit()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepository.GetAllBadges();

            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine($"----------------- \n" +
                    $"Badge Number: \n" +
                    $"{ badge.Key} \n" +
                    $"Accessible Doors:");

                foreach (string value in badge.Value)
                {
                    Console.WriteLine($"{value}");
                }
            }
        }

        private void SeedBadges()
        {

            Badge badge1 = new Badge(12345, new List<string>() { "A7" });
            Badge badge2 = new Badge(22345, new List<string>() { "A1", "A4", "B1", "B2" });
            Badge badge3 = new Badge(32345, new List<string>() { "A4", "A5" });

            _badgeRepository.CreateNewBadge(badge1.BadgeID, badge1.DoorAccess);
            _badgeRepository.CreateNewBadge(badge2.BadgeID, badge2.DoorAccess);
            _badgeRepository.CreateNewBadge(badge3.BadgeID, badge3.DoorAccess);
        }
    }
}
