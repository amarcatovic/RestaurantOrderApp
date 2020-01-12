using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.Dtos
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}