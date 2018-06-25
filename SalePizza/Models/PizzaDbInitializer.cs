using System;
using System.Data.Entity;

namespace SalePizza.Models
{
    public class PizzaDbInitializer : DropCreateDatabaseAlways<PizzaContext> //не удаляет, если изменены модели = исключение : CreateDatabaseIfNotExists
    {
        protected override void Seed(PizzaContext db)
        {
            db.Pizzas.Add(new Pizza { Name = "Пицца Терра острая", Composition = "соус Тартар, салями, перец Халапееньо, сыр Сливочный.", Diameter = 35.0f });
            db.Buyers.Add(new Buyer { Name = "Илья" });
            //db.Purchases.Add(new Purchase { Date = new DateTime(2018, 7, 20), Price = 7.8f} );
            base.Seed(db);
        }
    }
}