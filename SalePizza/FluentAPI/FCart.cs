using SalePizza.Models;
using System.Data.Entity.ModelConfiguration;

namespace SalePizza.FluentAPI
{
    public class FCart : EntityTypeConfiguration<Cart>
    {
        internal FCart()
        {
            HasKey(p => p.Id);

            Property(p => p.AverageCost)
                .IsRequired();
            //сделать больше нуля

            //много пицц в корзине
            HasMany(p => p.Pizzas)
                .WithMany(c => c.Carts);

            //один покупатель_одна корзина
            HasRequired(s => s.ApplicationUser)
                .WithOptional(d => d.Cart)
                .WillCascadeOnDelete(false);
        }
    }
}