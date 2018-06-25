using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SalePizza.Models
{
    public class PizzaContext : DbContext
    {

        public PizzaContext()
            : base("DbConnection")
        { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // использование Fluent API для модели Pizza
            modelBuilder.Entity<Pizza>().ToTable("Pizza");
            modelBuilder.Entity<Pizza>().HasKey(p => p.Id);
            modelBuilder.Entity<Pizza>().Property(p => p.Name).HasColumnName("PizzaName");
            modelBuilder.Entity<Pizza>().Property(p => p.Composition).HasColumnName("Description");
            modelBuilder.Entity<Pizza>().Property(p => p.Diameter).HasColumnName("Size");
            modelBuilder.Entity<Pizza>().Property(p => p.Name).IsRequired(); //Обязательное
            modelBuilder.Entity<Pizza>().Property(p => p.Composition).IsOptional(); //разрешаем нул
            modelBuilder.Entity<Pizza>().Property(p => p.Diameter).IsOptional();
            //modelBuilder.Entity<Pizza>().Property(p => p.Purchase).IsOptional();

            // использование Fluent API для модели Buyer
            modelBuilder.Entity<Buyer>().ToTable("Buyer");
            modelBuilder.Entity<Buyer>().Property(p => p.Name).HasColumnName("BuyerName");
            modelBuilder.Entity<Buyer>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Buyer>().Property(p => p.Id).IsRequired();

            // использование Fluent API для модели Purchase
            modelBuilder.Entity<Purchase>().ToTable("Purchase");
            modelBuilder.Entity<Purchase>().Property(p => p.Date).HasColumnName("DateOfPurchase");
            modelBuilder.Entity<Purchase>().Property(p => p.Price).HasColumnName("PriceOfPizza");
            modelBuilder.Entity<Purchase>().Property(p => p.Date).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Id).IsRequired();
            //modelBuilder.Entity<Purchase>().Property(p => p.PizzaId).IsRequired();
            //modelBuilder.Entity<Purchase>().Property(p => p.BuyerId).IsRequired();

            // связи моделей
            //modelBuilder.Entity<Buyer>()
            //    .HasRequired(c => c.Purchase)
            //    .WithRequiredPrincipal(c => c.Buyer); //один к одному покупка_покупатель

            //modelBuilder.Entity<Purchase>()
            //    .HasMany(c => c.Pizzas)
            //    .WithRequired(c => c.Purchase); //один ко многим покупка_пицца //Ключ обязывает наличие в таблице пицца...

            //Отключение каскадного удаления
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            base.OnModelCreating(modelBuilder);
        }

        static PizzaContext()
        {
            Database.SetInitializer<PizzaContext>(new PizzaDbInitializer());
        }

    }
}