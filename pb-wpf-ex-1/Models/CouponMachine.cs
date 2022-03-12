using System;
using System.Collections.Generic;
using System.Linq;

namespace pb_wpf_ex_1.Models
{
    public class CouponMachine
    {
        private readonly ICollection<string> coupons = new List<string>();

        public void Add(string coupon)
        {
            coupons.Add(coupon);
        }

        public string TakeRandom()
        {
            int randomIndex = new Random().Next(0, coupons.Count);
            string randomCoupon = coupons.ElementAt(randomIndex);

            return coupons.Remove(randomCoupon) ? randomCoupon : throw new Exception("Removing coupon was not successful");
        }

        public bool IsEmpty() => coupons.Count == 0;

        public IReadOnlyCollection<string> PeekCoupons()
        {
            return coupons.ToList().AsReadOnly();
        }
    }
}
