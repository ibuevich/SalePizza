using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SalePizza.Models
{
    public class PizzaDbInitializer : CreateDatabaseIfNotExists<PizzaContext> //не удаляет, если изменены модели = исключение : CreateDatabaseIfNotExists ; DropCreateDatabaseAlways
    {
        protected override void Seed(PizzaContext db)
        {
            db.Pizzas.AddOrUpdate(new Pizza { Name = "Пицца Терра острая", Composition = "соус Тартар, салями, перец Халапееньо, сыр Сливочный.", Diameter = 35.0, Price = 12.4});
            db.Pizzas.AddOrUpdate(new Pizza { Name = "Пицца Венеция", Composition = "соус сырный, мясо по домашнему, сыр Моцарелла", Diameter = 30.0, Price = 13.8 });
            db.Pizzas.AddOrUpdate(new Pizza { Name = "Пицца Маргарита", Composition = "помидоры, базилик, сыр Моцарелла.", Diameter = 32.0 , Price = 10.0 });
            db.Pizzas.AddOrUpdate(new Pizza { Name = "Пицца Вегетарианская", Composition = "соус для пиццы,помидоры, перец, оливки. лук, шампиньоны, мар. огурчики, сыр Моцарелла.", Diameter = 40.0, Price = 15.6 });
            db.Pizzas.AddOrUpdate(new Pizza { Name = "Пицца Арома", Composition = "соус чесночный, сыр Моцарелла, перец Халапеньо, ветчина, охотничьи колбаски, шампиньоны, кукуруза, маслины.", Diameter = 37.0 , Price = 9.7 });
            db.SaveChanges();
        }
    }
}