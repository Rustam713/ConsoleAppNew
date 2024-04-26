using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal PricePerGram { get; set; }
        public ProductType Type { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }


        public Products(int productId, string name, decimal pricePerGram, ProductType type, String unit, int count)
        {
            ProductId = productId;
            Name = name;
            Type = type;
            Count = count;
            Unit = unit;
            PricePerGram = pricePerGram;

        }
        public enum ProductType
        {
            Vegetable,
            Fruit,
            Meat,
            Spice
        }
    }
}
