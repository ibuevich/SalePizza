using System;
using SalePizza.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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
            // передаем все объекты в динамическое свойство в ViewBag
            ViewBag.Pizzas = pizzas;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.PizzaId = id;
            return View();
        }

        //[HttpPost]
        //public string Buy(Purchase purchase, Buyer buyer)
        //{
        //    purchase.Date = DateTime.Now;
        //    db.Buyers.Add()
        //    db.Purchases.Add(purchase); //добавление в бд заказа
        //    db.SaveChanges();
        //    return "Спасибо," + purchase.Buyer + ", за покупку!";
        //}

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