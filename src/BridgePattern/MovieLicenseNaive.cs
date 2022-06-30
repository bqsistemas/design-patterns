using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    /* public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime, DiscountMovie discountMovie)
            : base(movie, purchaseTime, discountMovie)
        {
        }

        protected override decimal GetPriceCore() => 4;
        public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);
    }

    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime, DiscountMovie discountMovie)
            : base(movie, purchaseTime, discountMovie)
        {
        }

        protected override decimal GetPriceCore() => 8;
        public override DateTime? GetExpirationDate() => null;
    }
    public class SpecialOfferSeniorTwoDaysLicense : SeniorTwoDaysLicense
    {
        public SpecialOfferSeniorTwoDaysLicense(string movie, DateTime purchaseTime, DiscountMovie discountMovie)
            : base(movie, purchaseTime, discountMovie)
        {
        }

        public override DateTime? GetExpirationDate()
        {
            DateTime? expirationDate = base.GetExpirationDate();
            return expirationDate?.AddDays(2);
        }
    } */
}
