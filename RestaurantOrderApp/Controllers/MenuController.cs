using RestaurantOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantOrderApp.ViewModel;

namespace RestaurantOrderApp.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _context;


        public MenuController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Menu
        public ActionResult Index()
        {
            var menu = new MenuViewModel
            {
                Drinks = _context.Drinks.ToList(),
                Meals = _context.Meals.ToList()
            };

            return View(menu);
        }
    }
}