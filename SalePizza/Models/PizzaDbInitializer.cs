using System.Collections.Generic;
using System.Data.Entity;

namespace SalePizza.Models
{
    public class PizzaDbInitializer : CreateDatabaseIfNotExists<PizzaContext> //не удаляет, если изменены модели = исключение : CreateDatabaseIfNotExists, DropCreateDatabaseAlways
    {
        protected override void Seed(PizzaContext db)
        {

            IList<Pizza> _Pizzas = new List<Pizza>();
            //IList<Buyer> defaultStandards2 = new List<Buyer>();

            db.Pizzas.Add(new Pizza { Name = "Пицца Терра острая", Composition = "соус Тартар, салями, перец Халапееньо, сыр Сливочный.", Diameter = 35.0f, Price = 12.4f});
            db.Pizzas.Add(new Pizza { Name = "Пицца Венеция", Composition = "соус сырный, мясо по домашнему, сыр Моцарелла", Diameter = 30.0f, Price = 13.8f });
            db.Pizzas.Add(new Pizza { Name = "Пицца Маргарита", Composition = "помидоры, базилик, сыр Моцарелла.", Diameter = 32.0f , Price = 10.0f });
            db.Pizzas.Add(new Pizza { Name = "Пицца Вегетарианская", Composition = "соус для пиццы,помидоры, перец, оливки. лук, шампиньоны, мар. огурчики, сыр Моцарелла.", Diameter = 40.0f, Price = 15.6f });
            db.Pizzas.Add(new Pizza { Name = "Пицца Арома", Composition = "соус чесночный, сыр Моцарелла, перец Халапеньо, ветчина, охотничьи колбаски, шампиньоны, кукуруза, маслины.", Diameter = 37.0f , Price = 9.7f });
            //db.Buyers.Add(new Buyer { Name = "Илья", Adress = "ул. Вологина 280-35"});
            //db.Purchases.Add(new Purchase { Date = new DateTime(2018, 7, 20), Price = 7.8f} );

            db.Pizzas.AddRange(_Pizzas);
            //db.Buyers.AddRange(defaultStandards2);

            base.Seed(db);
        }
    }
}