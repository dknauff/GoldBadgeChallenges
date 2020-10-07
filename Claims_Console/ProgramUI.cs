using Claims_Challenge_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Challenge
{
    public class ProgramUI
    {
        private readonly ClaimRepository _claimRepository = new ClaimRepository();

        public void Run()
        {
            SeedClaims();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you wish to select: \n" +
                    "1) See all claims \n" +
                    "2) Take care of next claim \n" +
                    "3) Enter a new claim \n" +
                    "4) Exit menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number that corresponds to a menu item!");
                        break;
                }
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<ClaimClass> claimList = _claimRepository.GetAllClaims();

            Console.WriteLine("ClaimID | Type   |   Description  |  Amount | DateOfIncident | DateOfClaim | IsValid \n");
            foreach (ClaimClass claim in claimList)
            {
                DisplayAllPropsForSeeAllClaims(claim);
            }
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        private void EnterNewClaim()
        {
            ClaimClass claim = new ClaimClass();

            Console.Clear();
            Console.WriteLine("Enter the claim ID:");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter the claim type: \n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft");
            string claimTypeResponse = Console.ReadLine();
            switch (claimTypeResponse)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
            }

            Console.Clear();
            Console.WriteLine("Enter a claim description:");
            claim.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter the amount of damage:");
            claim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter the date of the incident:");
            claim.DateOfIncident = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter the date of the claim:");
            claim.DateOfClaim = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Was the claim valid? \n" +
                "t for true \n" +
                "f for False");
            string isClaimValid = Console.ReadLine();
            if (isClaimValid.ToLower() == "t")
            {
                claim.IsValid = true;
            }
            else
            {
                claim.IsValid = false;
            }

            _claimRepository.AddClaimToDirectory(claim);

            Console.Clear();
            Console.WriteLine("Your new claim has been added to the directory! \n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayAllPropsForSeeAllClaims(ClaimClass claim)
        {
            Console.WriteLine($"   {claim.ClaimID} |   {claim.ClaimType} | {claim.Description} | {claim.ClaimAmount} |   {claim.DateOfIncident}   |   {claim.DateOfClaim} | {claim.IsValid} \n");
        }
        private void NextClaim()
        {
            Console.Clear();
            ClaimClass claim = _claimRepository.PeekQueue();

            Console.WriteLine($"Here are the details for this claim \n" +
            $"{claim.ClaimID} \n" +
            $"{claim.ClaimType} \n" +
            $"{claim.Description} \n" +
            $"{claim.ClaimAmount} \n" +
            $"{claim.DateOfIncident} \n" +
            $"{claim.DateOfClaim} \n" +
            $"{claim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "y")
            {
                _claimRepository.DeQueueClaim();
                Console.Clear();
                Console.WriteLine("The first claim has been pulled off the top of the queue. \n" +
                    "Press any key to return to the main menu...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
            }
        }
        private void SeedClaims()
        {
            var claimOne = new ClaimClass(1, ClaimType.Car, "Car accident on 465", 400.00m, "4/25/18", "4/27/18", true);
            var claimTwo = new ClaimClass(2, ClaimType.Home, "House fire in kitchen", 4000.00m, "4/11/18", "4/12/18", true);
            var claimThree = new ClaimClass(3, ClaimType.Theft, "Stolen pankcakes", 4.00m, "4/27/18", "6/01/18", false);

            _claimRepository.AddClaimToDirectory(claimOne);
            _claimRepository.AddClaimToDirectory(claimTwo);
            _claimRepository.AddClaimToDirectory(claimThree);
        }
    }
}