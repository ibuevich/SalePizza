using SalePizza.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NLog.LayoutRenderers;
using SalePizza.Filters;

namespace SalePizza.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        PizzaContext db = new PizzaContext();

        //тестируемый репозиторий
        IRepository repo;
        public HomeController(IRepository r)
        {
            repo = r;
        }

        public ActionResult Index()
        {
            // получаем из бд все объекты Pizza
            IEnumerable<Pizza> pizzas = db.Pizzas;
            // передаем все объекты в динамическое свойство в ViewBag
            ViewBag.Pizzas = pizzas;
            // возвращаем представление
            return View(repo.List());  /*return View();*/
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.PizzaId = id;
            return View();
        }

        [HttpGet]
        public ActionResult Cart()
        {
            string userid = User.Identity.GetUserId();
            IEnumerable<Cart> carts = db.Carts.Where(p => p.ApplicationUser.Id == userid).Include(f => f.Pizzas).ToList();
            ViewBag.Cart = carts;
            return View();
        }

        [MyAuth]
        [MyResult]
        public void AddToCart(int pizzaid)
        {
            Pizza pizza = db.Pizzas.Find(pizzaid);
            string userid = User.Identity.GetUserId();
            if (pizza != null)
            {
                var carttochange =
                    db.Carts.Where(p => p.ApplicationUser.Id == userid)
                        .ToList(); //.FirstOrDefault() - не работает, хотя логично выбирать Cart...
                carttochange[0].AverageCost += pizza.Price;
                carttochange[0].Pizzas.Add(pizza);
                db.SaveChanges();
            }
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