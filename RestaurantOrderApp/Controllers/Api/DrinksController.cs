﻿using AutoMapper;
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
    }
}
