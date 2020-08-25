using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionCore
{
    public class ProductCart
    {
        private readonly List<CartItem> _items = new List<CartItem>();
        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        public decimal Total { get; private set; }

        public ProductCart(List<CartItem> items, decimal total)
        {
            _items = items;
            Total = total;
        }
        public ProductCart(List<CartItem> items)
        {
            _items = items;
            Total = default;
        }
    }
}
