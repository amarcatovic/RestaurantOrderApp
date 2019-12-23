using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOrderApp.Models;

namespace RestaurantOrderApp.ViewModel
{
    public class MenuViewModel
    {
        public List<Drink> Drinks { get; set; }
        public List<Meal> Meals { get; set; }
    }
}