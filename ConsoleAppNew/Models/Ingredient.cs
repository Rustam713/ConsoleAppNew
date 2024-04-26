using ConsoleAppNew.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public int ProductID { get; set; }
        public int WeightGrams { get; set; }
        public int DishId { get; set; }
        public int IngredientID { get; set; }
        public int RestaurantId { get; set; }
    

        public Ingredient(int ingredientid, int productID, int weigthGrams, int dishes, int restaurants)
        {
            IngredientId = ingredientid;
            ProductID = productID;
            WeightGrams = weigthGrams;
            DishId = dishes;
            RestaurantId = restaurants;


        }

       
    }
}
