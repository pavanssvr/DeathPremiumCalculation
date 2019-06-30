using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using System.Security;

namespace DAL
{
    public class PremiumCalculationDAL : IPremiumCalculationDAL
    {
        public List<Models.OccupationFactor> GetOccupationOptions()
        {
            ////Getting data from Database through Entity framework
            //using (LifeInsuranceEntities dbContext = new LifeInsuranceEntities())
            //{
            //    return dbContext.Occupations.Join(dbContext.OccupationRatings, o => o.Rating, or => or.Rating, (o, or) => new { o, or })
            //        .Select(r => new Models.OccupationFactor { OccupationName = r.o.Occupation1, FactorValue = r.or.Factor.ToString() }).ToList();
            //}
            return GetOccupations();
        }

        //Hardcoded data will be returned if database ot available
        private List<Models.OccupationFactor> GetOccupations()
        {
            List<Models.Occupation> occupations = new List<Models.Occupation>();

            occupations.Add(new Models.Occupation { OccupationName = "Cleaner", Rating = "Light Manual" });
            occupations.Add(new Models.Occupation { OccupationName = "Doctor", Rating = "Professional" });
            occupations.Add(new Models.Occupation { OccupationName = "Author", Rating = "White Collar" });
            occupations.Add(new Models.Occupation { OccupationName = "Farmer", Rating = "Heavy Manual" });
            occupations.Add(new Models.Occupation { OccupationName = "Mechanic", Rating = "Heavy Manual" });
            occupations.Add(new Models.Occupation { OccupationName = "Florist", Rating = "Light Manual" });

            List<Models.OccupationRating> occupationRatings = new List<Models.OccupationRating>();
            occupationRatings.Add(new Models.OccupationRating { Rating = "Professional", Factor = Convert.ToDecimal(1.0) });
            occupationRatings.Add(new Models.OccupationRating { Rating = "White Collar", Factor = Convert.ToDecimal(1.25) });
            occupationRatings.Add(new Models.OccupationRating { Rating = "Light Manual", Factor = Convert.ToDecimal(1.50) });
            occupationRatings.Add(new Models.OccupationRating { Rating = "Heavy Manual", Factor = Convert.ToDecimal(1.75) });


            List<Models.OccupationFactor> listItems = (from o in occupations
                                                       join or in occupationRatings
                                                            on o.Rating equals or.Rating
                                                       select new Models.OccupationFactor()
                                                       {
                                                           OccupationName = o.OccupationName,
                                                           FactorValue = or.Factor.ToString()
                                                       }).ToList();
            return listItems;
        }
    }
}
