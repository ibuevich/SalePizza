using SalePizza.Models;
using System.Data.Entity.ModelConfiguration;

namespace SalePizza.FluentAPI
{
    public class FPurchase : EntityTypeConfiguration<Purchase>
    {
        internal FPurchase()
        {
            // использование Fluent API для модели Purchase
            HasKey(p => p.Id);

            Property(p => p.OrderDate)
                .IsRequired();

            Property(p => p.Price)
                .IsRequired();

            //много пицц в заказе
            HasMany(p => p.Pizzas)
                .WithMany(c => c.Purchases);

            ////один Пользователь в одном заказе
            //HasRequired(s => s.ApplicationUser)
            //    .WithOptional(d => d.Purchase)
            //    .WillCascadeOnDelete(false);
        }
    }
}