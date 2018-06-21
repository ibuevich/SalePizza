using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SalePizza.Models
{
        public class PizzaDbInitializer : DropCreateDatabaseAlways<PizzaContext>
        {
            protected override void Seed(PizzaContext db)
            {
                db.Pizzas.Add(new Pizza { Name = "Пицца Терра острая", Composition = "соус Тартар, салями, перец Халапееньо, сыр Сливочный.", Diameter = 45.0 });
                db.Buers.Add(new Buer { Name = "Илья", Id = 1 });
                db.Purchases.Add(new Purchase { Date = new DateTime(2018, 7, 20), Price = 7.8f, Id = 1, BuerId = 1 });

                base.Seed(db);
            }

        }

}