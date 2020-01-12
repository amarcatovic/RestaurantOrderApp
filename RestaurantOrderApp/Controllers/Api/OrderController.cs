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
            if (orderDto.MealIds == null && orderDto.DrinkIds == null)
                return BadRequest("Nothnig is ordered");
            
            //Initialize Lists
            List<Drink> drinks = new List<Drink>();
            List<Meal> meals = new List<Meal>();

            //If customer didn't order any drinks, don't query the database
           if(orderDto.DrinkIds != null)
                foreach (var temp in orderDto.DrinkIds)
                {
                    var _temp = _context.Drinks.SingleOrDefault(d => d.Id == temp);
                    if (_temp != null)
                        drinks.Add(_temp);
                }

            //If customer didn't order any meals, don't query the database
            if (orderDto.MealIds != null)
                foreach (var temp in orderDto.MealIds)
                {
                    var _temp = _context.Meals.SingleOrDefault(m => m.Id == temp);
                    if (_temp != null)
                        meals.Add(_temp);
                }

            //Get current time
            var timeNow = DateTime.Now;

           if (drinks.Count >= meals.Count)
            {
                for(int i = 0; i < drinks.Count; ++i)
                {
                    if(i >= meals.Count)
                    {
                        var order = new Order
                        {
                            TableId = orderDto.TableId,
                            drinkId = drinks[i].Id,
                            DateOrdered = timeNow
                        };
                        _context.Orders.Add(order);
                    }
                    else
                    {
                        var order = new Order
                        {
                            TableId = orderDto.TableId,
                            drinkId = drinks[i].Id,
                            mealId = meals[i].Id,
                            DateOrdered = timeNow
                        };
                        _context.Orders.Add(order);
                    }
                }
            }
           else
           {
                for (int i = 0; i < meals.Count; ++i)
                {
                    if (i >= drinks.Count)
                    {
                        var order = new Order
                        {
                            TableId = orderDto.TableId,   
                            mealId = meals[i].Id,
                            DateOrdered = timeNow
                        };
                        _context.Orders.Add(order);
                    }
                    else
                    {
                        var order = new Order
                        {
                            TableId = orderDto.TableId,
                            drinkId = drinks[i].Id,
                            mealId = meals[i].Id,
                            DateOrdered = timeNow
                        };
                        _context.Orders.Add(order);
                    }
                }
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
