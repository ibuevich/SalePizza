using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalePizza.Models;

namespace SalePizza.Controllers
{
    public class HomeController : Controller
    {

        // создаем контекст данных
        PizzaContext db = new PizzaContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Pizza
            IEnumerable<Pizza> pizzas = db.Pizzas;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = pizzas;
            // возвращаем представление
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}