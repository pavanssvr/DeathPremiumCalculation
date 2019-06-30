using Models;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IPremiumCalculationService
    {
        List<OccupationFactor> GetOccupationOptions();
        Decimal CalculateDeathPremium(Customer objCustomer);
    }
}
