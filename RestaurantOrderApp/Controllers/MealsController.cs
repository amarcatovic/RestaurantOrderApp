using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantOrderApp.Models;

namespace RestaurantOrderApp.Controllers
{
    public class MealsController : Controller
    {
        private ApplicationDbContext _context;


        public MealsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Meals
        public ActionResult Index()
        {
            return View();
        }
    }
}