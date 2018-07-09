using System.Data.Entity.ModelConfiguration;
using SalePizza.Models;

namespace SalePizza.FluentAPI
{
    public class FBuyer : EntityTypeConfiguration<Buyer>
    {
        internal FBuyer()
        {
            // использование Fluent API для модели Buyer
            HasKey(p => p.Id);

            //Property(p => p.Age)
            //    .IsRequired();

            //Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            Property(p => p.Adress)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.PurchaseId)
                .IsOptional();
        }
    }
}