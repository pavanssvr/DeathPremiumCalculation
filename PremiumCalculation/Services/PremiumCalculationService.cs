using System;
using System.Collections.Generic;
using DAL;
using Models;

namespace Services
{
    public class PremiumCalculationService : IPremiumCalculationService
    {
        private readonly IPremiumCalculationDAL _objDAL;
        public PremiumCalculationService(IPremiumCalculationDAL objDAL)
        {
            _objDAL = objDAL;
        }
        public List<Models.OccupationFactor> GetOccupationOptions()
        {
            if (_objDAL == null) throw new ArgumentNullException("DAL");
            return _objDAL.GetOccupationOptions();
        }

        public Decimal CalculateDeathPremium(Customer objCustomer)
        {
            if (objCustomer == null) throw new ArgumentNullException("Customer");
            if(objCustomer.DeathSumInsured == 0) throw new ArgumentNullException("DeathSumInsured");
            if (string.IsNullOrWhiteSpace(objCustomer.Factor)) throw new ArgumentNullException("Factor");
            if (objCustomer.Age == 0) throw new ArgumentNullException("Age");

            return (objCustomer.DeathSumInsured * Convert.ToDecimal(objCustomer.Factor) * objCustomer.Age) / 1000 * 12;
        }
    }
}
