using RestaurantOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.Dtos
{
    public class OrdersDto
    {
        public int TableId { get; set; }
        public DateTime DateOrdered { get; set; }
        public List<string> Drinks { get; set; }
        public List<string> Meals { get; set; }
    }
}