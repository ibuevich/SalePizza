using SalePizza.Models;
using System.Data.Entity.ModelConfiguration;


namespace SalePizza.FluentAPI
{
    public class FPizza : EntityTypeConfiguration<Pizza>
    {
        internal FPizza()
        {
            //использование Fluent API для модели Pizza 
            HasKey(p => p.Id);

            Property(p => p.Name)
                 .IsRequired()
                 .HasMaxLength(50);

            Property(p => p.Composition)
                 .IsOptional()
                 .HasMaxLength(150);

            Property(p => p.Diameter)
                 .IsOptional();

            Property(p => p.Price)
                .IsRequired();
                //найти что бы цена >0

            HasMany(p => p.Carts)
                .WithMany(c => c.Pizzas);

            HasMany(p => p.Purchases)
                .WithMany(c => c.Pizzas);
        }
    }
}