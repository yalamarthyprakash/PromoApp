using Models;
using PromotionCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromoEngineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var A = new Product('A', 50);
            var B = new Product('B', 30);
            var C = new Product('C', 20);
            var D = new Product('D', 15);

           // ICalculationService calculationService = new CalculationService();
            IList<IPromotionApply> promotions = new List<IPromotionApply>
            {
                new Apply('A', 3, 130),
                new Apply('B', 2, 45),
                new ComboCart(new List<char>{ 'C','D' },30)
            };

            //Scenario A
            var items = new List<CartItem>() { new CartItem(A, 1), new CartItem(B, 1), new CartItem(C, 1) };
            var cart = new ProductCart(items, Utility.CalculateTotalCost(items, promotions));
            ShowCartPrice(cart, "Scenario A");

            //Scenario B
            items = new List<CartItem>() { new CartItem(A, 5), new CartItem(B, 5), new CartItem(C, 1) };
            cart = new ProductCart(items, Utility.CalculateTotalCost(items, promotions));
            ShowCartPrice(cart, "Scenario B");

            //Scenario C
            items = new List<CartItem>() { new CartItem(A, 3), new CartItem(B, 5), new CartItem(C, 1), new CartItem(D, 1) };
            cart = new ProductCart(items, Utility.CalculateTotalCost(items, promotions));
            ShowCartPrice(cart, "Scenario C");

            System.Console.ReadLine();
        }

        private static void ShowCartPrice(ProductCart cart, string scenario)
        {
            System.Console.WriteLine(scenario);
            cart.Items.ToList().ForEach(x => System.Console.WriteLine($"{x.Product.SKU}   {x.Quantity}"));
            System.Console.WriteLine("_____________");
            System.Console.WriteLine("Total:: {0}",cart.Total);
            System.Console.WriteLine();
        }
    }
    
}
