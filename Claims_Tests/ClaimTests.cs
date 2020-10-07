using System;
using System.Collections.Generic;
using System.Security.Claims;
using Claims_Challenge_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Project_Tests
{
    [TestClass]
    public class ClaimTests
    {
        [TestMethod]
        public void AddClaimToDirectory_ShouldGetCorrectBoolean()
        {
            ClaimClass testClaim = new ClaimClass();
            ClaimRepository repository = new ClaimRepository();

            bool addClaim = repository.AddClaimToDirectory(testClaim);

            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnCorrectCollection()
        {
            ClaimClass testClaim = new ClaimClass();
            ClaimRepository repository = new ClaimRepository();
            repository.AddClaimToDirectory(testClaim);

            Queue<ClaimClass> listOfClaims = repository.GetAllClaims();

            bool directoryHasClaims = listOfClaims.Contains(testClaim);
            Assert.IsTrue(directoryHasClaims);
        }

        private ClaimRepository _repo;
        private ClaimClass _claim;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new ClaimClass(1, ClaimType.Car, "rough times", 10000m, "2/22/22", "3/33/33", false);
            _repo.AddClaimToDirectory(_claim);
        }
        [TestMethod]
        public void PeakClaim_ShouldPeekClaim()
        {
            ClaimClass claim = _repo.PeekQueue();

            Assert.AreEqual(_claim, claim);
        }
    }
}
