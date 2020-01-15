using RestaurantOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantOrderApp.Controllers
{
    public class DrinksController : Controller
    {
        private ApplicationDbContext _context;


        public DrinksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Drinks
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Drink d)
        {
            if(d.Id == 0)
            {
                _context.Drinks.Add(d);
            }
            else
            {
                var drink = _context.Drinks.Single(e => e.Id == d.Id);
                drink.Name = d.Name;
                drink.Price = d.Price;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Drinks");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }
    }
}