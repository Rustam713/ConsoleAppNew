namespace ConsoleAppNew.Models;

public class Product
{
    public class Products
    {
        public string Name { get; set; }
        public decimal PricePerGram { get; set; }
        public ProductType Type { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }

        public enum ProductType
        {
            Vegetable,
            Fruit,
            Meat,
            Spice
        }
    }
}