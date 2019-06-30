using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Services;
using DAL;

namespace PremiumCalculation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IPremiumCalculationDAL, PremiumCalculationDAL>();
            container.RegisterType<IPremiumCalculationService, PremiumCalculationService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}