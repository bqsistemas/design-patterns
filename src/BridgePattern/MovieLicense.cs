using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class MovieLicense
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }
        private readonly Discount _discount;
        private readonly LicenceType _licenceType;
        private readonly SpecialOffer _specialOffer;

        public MovieLicense(string movie, DateTime purchaseTime, Discount discount, LicenceType licenceType, SpecialOffer specialOffer = SpecialOffer.None)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
            _licenceType = licenceType;
            _specialOffer = specialOffer;
        }

        public decimal GetPrice()
        {
            int discount = GetDiscount();
            decimal multiplier = 1 - discount / 100m;
            return GetBasePrice() * multiplier;
        }
        private int GetDiscount()
        {
            return _discount switch
            {
                Discount.None => 0,
                Discount.Military => 10,
                Discount.Senior => 20,
                _ => throw new ArgumentException(),
            };
        }
        private  decimal GetBasePrice()
        {
            return _licenceType switch
            {
                LicenceType.LifeLong => 8,
                LicenceType.TwoDays => 4,
                _ => throw new ArgumentException(),
            };
        }
        public DateTime? GetExpirationDate()
        {
            DateTime? expirationDate = GetBaseExpirationDate();  
            TimeSpan extension = GetSpecialOfferExtension();
            return expirationDate?.Add(extension);
        }
        public TimeSpan GetSpecialOfferExtension()
        {
            return _specialOffer switch
            {
                SpecialOffer.None => TimeSpan.Zero,
                SpecialOffer.TwoDaysExtension => TimeSpan.FromDays(2),
                _ => throw new ArgumentException(),
            };
        }
        public DateTime? GetBaseExpirationDate()
        {
            return _licenceType switch
            {
                LicenceType.LifeLong => null,
                LicenceType.TwoDays => PurchaseTime.AddDays(2),
                _ => throw new ArgumentException(),
            };
        }
    }
}
