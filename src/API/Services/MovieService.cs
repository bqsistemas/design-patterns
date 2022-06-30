using API.Services.Interfaces;
using BridgePattern;
using Business.Enums;
using Business.Models;
using CommandPattern;
using CommandPattern.Commands;
using StrategyPattern.Models;
using StrategyPattern.Strategies.Comparer;
using StrategyPattern.Strategies.Invoice;
using StrategyPattern.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class MovieService : IMovieService
    {

        public MovieService()
        {
        }
        public object GetMoviePrices()
        {
            /* var noDiscount = new NoDiscount();
            var militaryDiscount = new MilitaryDiscount();
            var seniorDiscount = new SeniorDiscount(); 

            var license1 = new TwoDaysLicense("Secret Life of Pets", DateTime.Now, noDiscount);
            var license2 = new LifeLongLicense("Matrix", DateTime.Now, noDiscount);
            var license3 = new TwoDaysLicense("Secret Life of Pets", DateTime.Now, militaryDiscount);
            var license4 = new LifeLongLicense("Matrix", DateTime.Now, seniorDiscount);
            */

            var license1 = new MovieLicense("Secret Life of Pets", DateTime.Now, Discount.None, LicenceType.TwoDays);
            var license2 = new MovieLicense("Matrix", DateTime.Now, Discount.None, LicenceType.LifeLong);
            var license3 = new MovieLicense("Secret Life of Pets", DateTime.Now, Discount.Military, LicenceType.TwoDays);
            var license4 = new MovieLicense("Matrix", DateTime.Now, Discount.Senior, LicenceType.LifeLong);

            var license5 = new MovieLicense("Matrix", DateTime.Now, Discount.Senior, LicenceType.TwoDays, SpecialOffer.TwoDaysExtension);


            return new
            {
                licence1NoDiscount = new
                {
                    name = license1.Movie,
                    price = license1.GetPrice(),
                    expiration = GetValidFor(license1)
                },
                licence2NoDiscount = new
                {
                    name = license2.Movie,
                    price = license2.GetPrice(),
                    expiration = GetValidFor(license2)
                },
                licence3MilitaryDiscount = new
                {
                    name = license3.Movie,
                    price = license3.GetPrice(),
                    expiration = GetValidFor(license3)
                },
                licence4SeniorDiscount = new
                {
                    name = license4.Movie,
                    price = license4.GetPrice(),
                    expiration = GetValidFor(license4)
                },
                licence5SpecialOffer = new
                {
                    name = license5.Movie,
                    price = license5.GetPrice(),
                    expiration = GetValidFor(license5)
                }
            };
        }

        private static string GetValidFor(MovieLicense license)
        {
            DateTime? expirationDate = license.GetExpirationDate();

            if (expirationDate == null)
                return "Forever";

            TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

            return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }
    }
}
