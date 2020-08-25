using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionCore
{
    public static class Utility
    {
        public static decimal CalculateTotalCost(IEnumerable<CartItem> items, IEnumerable<IPromotionApply> promotions)
        {
            var casherCart = new ProductCart(items.ToList());

            foreach (var promotion in promotions)
            {
                casherCart = promotion.CalculateCartAmount(casherCart);
            }
            var leftoverItemsCost = casherCart.Items.Any() ? casherCart.Items.Sum(x => x.Product.Price) : default;

            return casherCart.Total + leftoverItemsCost;
        }
    }
}
