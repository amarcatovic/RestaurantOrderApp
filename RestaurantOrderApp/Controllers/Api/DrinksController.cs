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
            var drinksFromDb = _context.Drinks;
            if (!String.IsNullOrWhiteSpace(query))
                drinksFromDb.Where(d => d.Name.Contains(query));

            var customerDto = drinksFromDb.ToList().Select(Mapper.Map<Drink, DrinkDto>);

            return Ok(customerDto);
        }
    }
}
