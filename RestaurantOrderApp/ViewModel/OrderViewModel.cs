using RestaurantOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.ViewModel
{
    public class OrderViewModel
    {
        public List<Drink> Drinks { get; set; }
        public List<Meal> Meals { get; set; }
        public Meal tempMeal { get; set; }
        public Drink tempDrink { get; set; }
        public List<Drink> DrinksOrdered { get; set; }
        public List<Meal> MealsOrdered { get; set; }

    }
}