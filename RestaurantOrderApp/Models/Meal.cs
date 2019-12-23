using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.Models
{
    public class Meal
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}