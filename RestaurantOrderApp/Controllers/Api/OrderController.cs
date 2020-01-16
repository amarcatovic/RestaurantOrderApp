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

        public IHttpActionResult GetOrders()
        {
            List<OrdersDto> orders = new List<OrdersDto>();
            var ordersFromDb = _context.Orders.ToList();

            if (ordersFromDb.Count == 0)
                return BadRequest("No orders");

            foreach(var ord in ordersFromDb)
            {
                if(orders.Count == 0)
                {
                    OrdersDto temp = new OrdersDto
                    {
                        TableId = ord.TableId,
                        DateOrdered = ord.DateOrdered
                    };
                    temp.Drinks = new List<string>();
                    var singleDrinkFromDb = _context.Drinks.SingleOrDefault(d => d.Id == ord.drinkId);
                    if (singleDrinkFromDb != null)
                        temp.Drinks.Add(singleDrinkFromDb.Name);
                    temp.Meals = new List<string>();
                    var singleMealFromDb = _context.Meals.SingleOrDefault(d => d.Id == ord.mealId);
                    if (singleMealFromDb != null)
                        temp.Meals.Add(singleMealFromDb.Name);
                    orders.Add(temp);
                    continue;
                }

                if(!(orders[orders.Count - 1].TableId == ord.TableId && orders[orders.Count - 1].DateOrdered == ord.DateOrdered))
                {
                    OrdersDto temp = new OrdersDto
                    {
                        TableId = ord.TableId,
                        DateOrdered = ord.DateOrdered
                    };
                    temp.Drinks = new List<string>();
                    var singleDrinkFromDb = _context.Drinks.SingleOrDefault(d => d.Id == ord.drinkId);
                    if(singleDrinkFromDb != null)
                        temp.Drinks.Add(singleDrinkFromDb.Name);
                    temp.Meals = new List<string>();
                    var singleMealFromDb = _context.Meals.SingleOrDefault(d => d.Id == ord.mealId);
                    if(singleMealFromDb != null)
                        temp.Meals.Add(singleMealFromDb.Name);
                    orders.Add(temp);
                }
                else
                {
                    var singleDrinkFromDb = _context.Drinks.SingleOrDefault(d => d.Id == ord.drinkId);
                    var singleMealFromDb = _context.Meals.SingleOrDefault(d => d.Id == ord.mealId);

                    if (singleDrinkFromDb != null)
                        orders[orders.Count - 1].Drinks.Add(singleDrinkFromDb.Name);
                    if (singleMealFromDb != null)
                        orders[orders.Count - 1].Meals.Add(singleMealFromDb.Name);
                }
            }
            return Ok(orders);
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
