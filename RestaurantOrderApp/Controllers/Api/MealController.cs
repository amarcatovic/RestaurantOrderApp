using AutoMapper;
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
    public class MealController : ApiController
    {
        private ApplicationDbContext _context;
        public MealController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult getMeals(string query = null)
        {
            if (String.IsNullOrWhiteSpace(query))
                return Ok(_context.Meals.ToList().Select(Mapper.Map<Meal, MealDto>));
           
            var mealsFromDb = _context.Meals.Where(m => m.Name.Contains(query));
            var mealsDto = mealsFromDb.ToList().Select(Mapper.Map<Meal, MealDto>);
            return Ok(mealsDto);
        }
        [HttpPost]
        public IHttpActionResult createMeal(MealDto mealDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid");

            var meal = Mapper.Map<MealDto, Meal>(mealDto);
            _context.Meals.Add(meal);
            _context.SaveChanges();
            mealDto.Id = meal.Id;

            return Created(new Uri(Request.RequestUri + "/" + mealDto.Id), mealDto);
        }
    }
}
