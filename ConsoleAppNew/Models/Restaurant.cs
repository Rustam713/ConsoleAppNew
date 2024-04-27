using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string HeadChef { get; set; }
        public string Address { get; set; }

        public decimal CashBalance { get; set; }

       

        public Restaurant(int restaurantId, string name, string headChef, string address)
        {
            RestaurantId = restaurantId;
            Name = name;
            HeadChef = headChef;
            Address = address;
        }

        public Restaurant(int restaurantId)
        {
            RestaurantId = restaurantId;
        }

    }
}
