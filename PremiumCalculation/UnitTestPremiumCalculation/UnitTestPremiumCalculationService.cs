using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using DAL;
using Services;

namespace UnitTestPremiumCalculation
{
    [TestClass]
    public class UnitTestPremiumCalculationService
    {
        private readonly IPremiumCalculationDAL objDAL;
        [TestMethod]
        public void TestWhiteCollarDeathPremium()
        {
            Customer objWhiteCollarCustomer = new Customer() { Age= 26, DeathSumInsured= 100000, Factor= "1.25"};

            IPremiumCalculationService objService = new PremiumCalculationService(objDAL);
            Decimal premiumAmount = Math.Round(objService.CalculateDeathPremium(objWhiteCollarCustomer),2);

            Assert.AreEqual(premiumAmount, 39000);
        }

        [TestMethod]
        public void TestHeavyManualDeathPremium()
        {
            Customer objHeavyManualCustomer = new Customer() { Age = 40, DeathSumInsured = 100000, Factor = "1.75" };

            IPremiumCalculationService objService = new PremiumCalculationService(objDAL);
            Decimal premiumAmount = Math.Round(objService.CalculateDeathPremium(objHeavyManualCustomer), 2);

            Assert.AreEqual(premiumAmount, 84000);
        }

        [TestMethod]
        public void TestProfessionalDeathPremium()
        {
            Customer objProfessionalCustomer = new Customer() { Age = 45, DeathSumInsured = 100000, Factor = "1.0" };

            IPremiumCalculationService objService = new PremiumCalculationService(objDAL);
            Decimal premiumAmount = Math.Round(objService.CalculateDeathPremium(objProfessionalCustomer), 2);

            Assert.AreEqual(premiumAmount, 54000);
        }
    }
}
