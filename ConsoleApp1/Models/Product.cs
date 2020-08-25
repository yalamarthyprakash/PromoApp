using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Product
    {
        public char SKU { get; private set; }
        public decimal Price { get; private set; }

        public Product(char sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
    }
}
