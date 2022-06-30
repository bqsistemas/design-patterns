using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enums
{
    public enum ItemType
    {
        Literature = 1
    }
    public enum ShippingStatus
    {
        WaitingForPayment = 1
    }
    public enum ShipProvider
    {
        DHL = 1,
        UPS = 2,
        FEDEX = 3,
        SERPOST = 4,
    }
    public enum ChangeQuantityType
    {
        Increase = 1,
        Decrease = 2,
    }

    public enum LicenceType
    {
        TwoDays,
        LifeLong
    }

    public enum Discount
    {
        None,
        Military,
        Senior
    }

    public enum SpecialOffer
    {
        None,
        TwoDaysExtension
    }
    public enum MpaaRating
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4
    }
}
