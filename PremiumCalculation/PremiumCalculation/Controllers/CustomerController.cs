using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Services;
using Models;

namespace PremiumCalculation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IPremiumCalculationService _repository;

        public CustomerController(IPremiumCalculationService repository)
        {
            _repository = repository;
        }
        
        public ActionResult Enter()
        {
            ViewBag.Occupations = GetListItems();
            return View("CalculatePremium");
        }

        //This action mehtod will be called on button submission        
        public ActionResult CalculatePremium(Customer objCustomer)
        {
            ViewBag.Occupations = GetListItems();
            ViewData["PremiumAmount"] = Math.Round(_repository.CalculateDeathPremium(objCustomer), 2);
            return View();
        }

        //This action mehtod will be called on Occupation dropdown change 
        public JsonResult CalculatePremiumJson(Customer objCustomer)
        {
            ViewData["PremiumAmount"] = "";
            ViewBag.Occupations = GetListItems();
            return Json(new { PremiumAmount = Math.Round(_repository.CalculateDeathPremium(objCustomer), 2) }, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetListItems()
        {
            return _repository.GetOccupationOptions().ConvertAll(listItem =>
            {
                return new SelectListItem() {  Text = listItem.OccupationName, Value = listItem.FactorValue   };
            });
        }
    }
}