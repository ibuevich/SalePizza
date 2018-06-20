using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace SalePizza.Models
{
    public class PizzaContext : DbContext
    {

        public PizzaContext()
            : base("DbConnection")
        { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Buer> Buers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}