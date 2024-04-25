using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNew.Models
{
    internal class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public int IngredientsId { get; set; }


        public Dish(int dishId, string name, decimal price, int restaurant, int ingredients)
        {
            DishId = dishId;
            Name = name;
            RestaurantId = restaurant;
            IngredientsId = ingredients;
            Price = price;

        }
    }
}
