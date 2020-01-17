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
    public class DrinksController : ApiController
    {
        private ApplicationDbContext _context;
        public DrinksController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetDrinks(string query = null)
        {
            if (String.IsNullOrWhiteSpace(query))
                return Ok(_context.Drinks.ToList().Select(Mapper.Map<Drink, DrinkDto>));

            var drinksFromDb = _context.Drinks.Where(d => d.Name.Contains(query));
            var drinksDto = drinksFromDb.ToList().Select(Mapper.Map<Drink, DrinkDto>);
            return Ok(drinksDto);
        }

        [HttpPost]
        public IHttpActionResult createDrink(DrinkDto drinkDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var drink = Mapper.Map<DrinkDto, Drink>(drinkDto);

            _context.Drinks.Add(drink);
            _context.SaveChanges();

            drinkDto.Id = drink.Id;
            return Created(new Uri(Request.RequestUri + "/" + drink.Id), drinkDto);
        }

        [HttpPut]
        public IHttpActionResult updateDrink(DrinkDto drinkDto)
        {

            if (!ModelState.IsValid)
                return BadRequest("ModelState is not Valid");

            var drink = _context.Drinks.SingleOrDefault(d => d.Id == drinkDto.Id);
            if (drink == null)
                return BadRequest("Drink has not been found");

            Mapper.Map(drinkDto, drink);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult deleteDrink(int id)
        {
            var drinkFromDb = _context.Drinks.SingleOrDefault(d => d.Id == id);
            if (drinkFromDb == null)
                return BadRequest("Drink not found");

            _context.Drinks.Remove(drinkFromDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
