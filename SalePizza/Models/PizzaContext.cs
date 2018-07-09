using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SalePizza.FluentAPI;

namespace SalePizza.Models
{
    public class PizzaContext : DbContext
    {

        public PizzaContext()
            : base("DbConnection")
        {
            Database.SetInitializer(new PizzaDbInitializer());
        }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Buyer> Buyers { get; set; }
        
        public DbSet<Purchase> Purchases { get; set; }

        static PizzaContext()
        {
            Database.SetInitializer<PizzaContext>(new PizzaDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new FBuyer());
            modelBuilder.Configurations.Add(new FPizza());
            modelBuilder.Configurations.Add(new FPurchase());
        }

    }
}