using SalePizza.Models;
using System.Data.Entity.ModelConfiguration;

namespace SalePizza.FluentAPI
{
    public class FApplicationUser : EntityTypeConfiguration<ApplicationUser>
    {
        internal FApplicationUser()
        {
            // использование Fluent API для модели ApplicationUser
            HasKey(p => p.Id);

            Property(p => p.Birthday)
                .IsRequired();

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            ////много покупок у пользователя
            //HasMany(p => p.Purchases)
            //    .WithMany(c => c.ApplicationUsers);

        }
    }
}