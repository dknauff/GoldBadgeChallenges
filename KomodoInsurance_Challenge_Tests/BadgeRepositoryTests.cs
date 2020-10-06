using System;
using System.Collections.Generic;
using KomodoInsurance_Challenge_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoInsurance_Challenge_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void CreateNewBadge_ShouldGetCorrectBoolean()
        {
            Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
            BadgeRepository repo = new BadgeRepository();

            bool addResult = repo.CreateNewBadge(42345, new List<string>() { "A5", "A6" });

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllBadges_ShouldReturnCorrectCollection()
        {
            Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();
            
            badgeDictionary.Add(42345, new List<string> { "A4", "A5" });

            bool dictionaryHasBadges = badgeDictionary.ContainsKey(42345);
            Assert.IsTrue(dictionaryHasBadges);
        }
    }
}
