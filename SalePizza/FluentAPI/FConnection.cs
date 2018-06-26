using SalePizza.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SalePizza.FluentAPI
{
    public class FConnection : DbContext
    {
        // связи моделей
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////один к одному покупка_покупатель
            //modelBuilder.Entity<Purchase>()
            //    .HasRequired(c => c.Buyer)
            //    .WithRequiredPrincipal(c => c.Purchase);

            ////один ко многим покупка_пицца
            //modelBuilder.Entity<Purchase>()
            //    .HasMany(p => p.Pizzas)
            //    .WithRequired(p => p.Purchase);

            ////Отключение каскадного удаления
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            //base.OnModelCreating(modelBuilder);
        }
    }
}