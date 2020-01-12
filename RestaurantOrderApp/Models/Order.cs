using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int drinkId { get; set; }
        public int mealId { get; set; }
        public DateTime DateOrdered { get; set; }
    }
}