using RestaurantOrderApp.Dtos;
using RestaurantOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantOrderApp.Controllers.Api
{
    public class OrderController : ApiController
    {
        private ApplicationDbContext _context;
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(OrderDto orderDto)
        {
            var drinks = _context.Drinks.Where(d => orderDto.DrinkIds.Contains(d.Id)).ToList();

            foreach(var drink in drinks)
            {
                var order = new Order
                {
                    TableId = orderDto.TableId,
                    drinkId = drink.Id,
                    DateOrdered = DateTime.Now
                };
                _context.Orders.Add(order);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
