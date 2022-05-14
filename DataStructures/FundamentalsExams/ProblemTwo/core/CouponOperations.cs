using System;
using System.Collections.Generic;
using System.Linq;

namespace CouponOps
{
    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Coupon> coupons;
        private Dictionary<string, Website> websites;
        private Dictionary<Website, List<Coupon>> websiteCoupons;
        private Dictionary<Coupon, Website> couponWeb;
        public CouponOperations()
        {
            this.coupons = new Dictionary<string, Coupon>();
            this.websites = new Dictionary<string, Website>();
            this.websiteCoupons = new Dictionary<Website, List<Coupon>>();
            this.couponWeb = new Dictionary<Coupon, Website>();
        }

        public void RegisterSite(Website w)
        {
            if (this.websites.ContainsKey(w.Domain))
            {
                throw new ArgumentException();
            }

            this.websites.Add(w.Domain, w);
            this.websiteCoupons.Add(w, new List<Coupon>());
        }

        public void AddCoupon(Website w, Coupon c)
        {
            if (!this.websites.ContainsKey(w.Domain))
            {
                throw new ArgumentException();
            }

            this.coupons.Add(c.Code, c);
            this.websiteCoupons[w].Add(c);
            this.couponWeb.Add(c, w);
        }

        public Website RemoveWebsite(string domain)
        {
            Website web;

            if (!this.websites.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            web = this.websites[domain];
            
            var couponsToRemove = this.websiteCoupons[web].ToList();

            foreach (var item in couponsToRemove)
            {
                this.coupons.Remove(item.Code);
                this.couponWeb.Remove(item);
            }

            this.websiteCoupons.Remove(web);
            this.websites.Remove(domain);

            return web;
        }

        public Coupon RemoveCoupon(string code)
        {
            Coupon coupon;

            if (!this.coupons.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            coupon = this.coupons[code];
            var web = this.couponWeb[coupon];

            this.coupons.Remove(code);
            this.websiteCoupons[web].Remove(coupon);
            this.couponWeb.Remove(coupon);

            return coupon;
        }

        public bool Exist(Website w)
        {
            return this.websites.ContainsKey(w.Domain);
        }

        public bool Exist(Coupon c)
        {
            return this.coupons.ContainsKey(c.Code);
        }

        public IEnumerable<Website> GetSites()
        {
            var result = this.websites.Values.ToList();

            return result;
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website w)
        {
            if (!this.websites.ContainsKey(w.Domain))
            {
                throw new ArgumentException();
            }

            var result = this.websiteCoupons[w].ToList();
            return result;
        }

        public void UseCoupon(Website w, Coupon c)
        {
            if (!this.websites.ContainsKey(w.Domain))
            {
                throw new ArgumentException();
            }

            if (!this.coupons.ContainsKey(c.Code))
            {
                throw new ArgumentException();
            }

            if(this.couponWeb[c].Domain != w.Domain)
            {
                throw new ArgumentException();
            }

            this.coupons.Remove(c.Code);
            this.websiteCoupons[w].Remove(c);
            this.couponWeb.Remove(c);
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return this.coupons.OrderByDescending(x => x.Value.Validity)
                .OrderByDescending(x => x.Value.DiscountPercentage)
                .Select(x => x.Value)
                .ToList();
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            return this.websiteCoupons.OrderByDescending(x => x.Key.UsersCount)
                .OrderByDescending(c => c.Value.Count)
                .Select(x => x.Key)
                .ToList();
        }
    }
}
