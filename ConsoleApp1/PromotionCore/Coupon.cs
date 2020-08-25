using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionCore
{
    public class Coupon : IPromotionApply
    {
        public Product Product { get; private set; }
        public decimal DiscountPersentage { get; private set; }

        public Coupon(Product product, decimal discountPersentage)
        {
            Product = product;
            DiscountPersentage = discountPersentage;
        }
        public ProductCart CalculateCartAmount(ProductCart cart)
        {
            
            throw new NotImplementedException();
        }
    }
}
