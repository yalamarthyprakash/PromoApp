using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionCore
{
    public class ComboCart:IPromotionApply
    {
        public IEnumerable<char> ComboSku { get; private set; }
        public decimal FlatPrice { get; private set; }

        public ComboCart(IEnumerable<char> comboSku, decimal flatAmount)
        {
            if (comboSku == null || !comboSku.Any() || flatAmount == default)
                throw new ArgumentNullException();

            ComboSku = comboSku;
            FlatPrice = flatAmount;
        }

        public ProductCart CalculateCartAmount(ProductCart cart)
        {
            decimal total = default;

            var items = cart.Items.Where(x => ComboSku.Any(c => c == x.Product.SKU)).ToList();

            var numberOfCombos = ComboSku.Select(x => items.Count(i => i.Product.SKU == x)).Min();

            if (numberOfCombos > 0)
            {
                total = FlatPrice * numberOfCombos;

                var calculatedItems = new List<CartItem>();

                foreach (var sku in ComboSku)
                {
                    calculatedItems.AddRange(items.Where(x => x.Product.SKU == sku).Take(numberOfCombos));
                }

                var uncalculatedItems = items.Except(calculatedItems);

                total += uncalculatedItems.Any() ? uncalculatedItems.Sum(x => x.Product.Price) : default;

                return new ProductCart(cart.Items.Except(items).ToList(), cart.Total + total);
            }
            return cart;

        }
    }
}
