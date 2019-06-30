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
            try
            {
                ViewBag.Occupations = GetListItems();
            }
            catch(Exception ex)
            {
               ///TODO : Handle the exception and show the proper message
            } 
            return View("CalculatePremium");

        }

        //This action mehtod will be called on button submission        
        public ActionResult CalculatePremium(Customer objCustomer)
        {
            try
            {
                ViewBag.Occupations = GetListItems();
                ViewData["PremiumAmount"] = Math.Round(_repository.CalculateDeathPremium(objCustomer), 2);
            }
            catch (Exception ex)
            {
                ///TODO : Handle the exception and show the proper message
            }
            return View();
        }

        //This action mehtod will be called on Occupation dropdown change 
        public JsonResult CalculatePremiumJson(Customer objCustomer)
        {
            decimal premiumAmount = 0;
            try
            {
                ViewData["PremiumAmount"] = "";
                ViewBag.Occupations = GetListItems();
                premiumAmount = Math.Round(_repository.CalculateDeathPremium(objCustomer), 2);
            }
            catch (Exception ex)
            {
                ///TODO : Handle the exception and show the proper message
            }
            return Json(new { PremiumAmount = premiumAmount }, JsonRequestBehavior.AllowGet);
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
