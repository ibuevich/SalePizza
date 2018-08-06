using Microsoft.AspNet.Identity;
using SalePizza.Filters;
using SalePizza.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalePizza.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        PizzaContext db = new PizzaContext();

        //public ActionResult Index()
        //{
        //    IEnumerable<Pizza> pizzas = db.Pizzas;
        //    ViewBag.Pizzas = pizzas;
        //    return View();
        //}

        // асинхронный метод
        public async Task<ActionResult> Index()
        {   
            CancellationTokenSource cts = new CancellationTokenSource();

            IEnumerable<Pizza> pizzas = await db.Pizzas.ToListAsync(cts.Token);
            cts.CancelAfter(5000);
            ViewBag.Pizzas = pizzas;
            return View("Index");
        }

        [MyAuth]
        [Authorize]
        [HttpGet]
        public ActionResult Cart()
        {
            string userId = User.Identity.GetUserId();
            var cart = db.Carts
                .Include(f => f.Pizzas)
                .Single(p => p.ApplicationUser.Id == userId);
            return View(cart);
        }

        [MyAuth]
        [MyResult]
        [Authorize]
        public void AddToCart(int pizzaid)
        {
            Pizza pizza = db.Pizzas.Find(pizzaid);
            string userId = User.Identity.GetUserId();
            if (pizza != null)
            {
                var cartToChange =
                    db.Carts.Where(p => p.ApplicationUser.Id == userId)
                        .ToListAsync().Result; //.FirstOrDefault() - не работает, хотя логично выбирать Cart...
                cartToChange[0].AverageCost += pizza.Price;
                cartToChange[0].Pizzas.Add(pizza);
               db.SaveChangesAsync();
            }
        }

        [MyAuth]
        [Authorize]
        public string AddToPurchase(Purchase purchase, int Apartmen, string Town, string House, string Street) //добавление данных в бд удаление из корзины
        {
            //if (ModelState.IsValid)
            //{
            purchase.OrderDate = DateTime.Now;
            purchase.Apartmen = Apartmen;
            purchase.Town = Town;
            purchase.Street = Street;
            purchase.House = House;
            purchase.Address = $"Г. {Town}, Ул. {Street}, д. {House}-{Apartmen}";
            string userId = User.Identity.GetUserId();
            var currenUser = db.Users.Where(p => p.Id == userId).ToList();
            purchase.ApplicationUser = currenUser[0];
            db.Purchases.Add(purchase);
            db.SaveChanges();

            //очищение корзины

            return "Спасибо, " + purchase.ApplicationUser.Name + ", за покупку!"; //+ purchase.ApplicationUser +
            //}
            //else
            //{
            //   return "Ошибки заполнения, данные не были сохранены";
            //}
        }

        public ActionResult Details(int cartId)
        {
            IEnumerable<Cart> carts = db.Carts;
            Cart userCart = carts.FirstOrDefault(cart => cart.Id == cartId);

            if (userCart != null)
            {
                return PartialView(userCart);
            }

            return HttpNotFound();
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