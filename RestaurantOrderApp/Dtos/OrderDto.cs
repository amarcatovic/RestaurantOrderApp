using RestaurantOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.Dtos
{
    public class OrderDto
    {
        public int TableId { get; set; }
        public List<int> DrinkIds { get; set; }
        public List<int> MealIds { get; set; }
    }
}