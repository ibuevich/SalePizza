using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using SalePizza.FluentAPI;

namespace SalePizza.Models
{
    public class PizzaContext : IdentityDbContext<ApplicationUser>    //: DbContext 
    {

        //Identity and Authorization
        public DbSet<IdentityUserLogin> UserLogins { get; set; }

        public DbSet<IdentityUserClaim> UserClaims { get; set; }

        public DbSet<IdentityUserRole> UserRoles { get; set; }


        //My custom DbSets
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public PizzaContext()
            : base("DbConnection")
        {
            Database.SetInitializer(new PizzaDbInitializer()); //<PizzaContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        static PizzaContext()
        {
            Database.SetInitializer(new PizzaDbInitializer());
        }

        public static PizzaContext Create()
        {
            return new PizzaContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new FApplicationUser());
            modelBuilder.Configurations.Add(new FCart());
            modelBuilder.Configurations.Add(new FPizza());
            modelBuilder.Configurations.Add(new FPurchase());
        }

    }
}