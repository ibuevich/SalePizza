﻿using System.Data.Entity.ModelConfiguration;
using SalePizza.Models;

namespace SalePizza.FluentAPI
{
    public class FBuer : EntityTypeConfiguration<Buyer>
    {
        internal FBuer()
        {
            // использование Fluent API для модели Buyer
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Adress)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.PurchaseId)
                .IsOptional();
        }
    }
}