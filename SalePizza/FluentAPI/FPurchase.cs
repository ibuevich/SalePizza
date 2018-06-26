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

            Property(p => p.Date)
                .IsRequired();
            Property(p => p.Price)
                .IsRequired();

            //много пицц в одном заказе
            HasRequired(s => s.Pizza)
                .WithOptional(s => s.Purchase)
                .WillCascadeOnDelete(false);

                //.WithMany(d => d.Purchases)
                //.HasForeignKey(s => s.PizzaId)
                //.WillCascadeOnDelete(false);

            //один покупатель в одном заказе
            HasRequired(s => s.Buyer)
                .WithOptional(d => d.Purchase)
                .WillCascadeOnDelete(false);
            //.WithRequiredPrincipal(d => d.Purchase)
            //.WillCascadeOnDelete(false);
        }
    }
}