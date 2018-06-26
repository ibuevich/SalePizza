using System.Collections.Generic;
using System.Data.Entity;

namespace SalePizza.Models
{
    public class PizzaDbInitializer : DropCreateDatabaseAlways<PizzaContext> //не удаляет, если изменены модели = исключение : CreateDatabaseIfNotExists, DropCreateDatabaseAlways
    {
        protected override void Seed(PizzaContext db)
        {

            IList<Pizza> defaultStandards = new List<Pizza>();
            IList<Buyer> defaultStandards2 = new List<Buyer>();

            db.Pizzas.Add(new Pizza { Name = "Пицца Терра острая", Composition = "соус Тартар, салями, перец Халапееньо, сыр Сливочный.", Diameter = 35.0f });
            db.Buyers.Add(new Buyer { Name = "Илья" });
            //db.Purchases.Add(new Purchase { Date = new DateTime(2018, 7, 20), Price = 7.8f} );

            db.Pizzas.AddRange(defaultStandards);
            db.Buyers.AddRange(defaultStandards2);

            base.Seed(db);
        }
    }
}