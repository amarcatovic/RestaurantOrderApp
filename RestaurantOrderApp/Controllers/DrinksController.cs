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
        public ActionResult Index()
        {
            return View();
        }
    }
}