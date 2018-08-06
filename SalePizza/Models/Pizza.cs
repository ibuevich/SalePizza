using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalePizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Diameter { get; set; }

        public string Composition { get; set; }

        [Range(0.0, Double.MaxValue)] //поискать в флюент
        public double Price { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

        public Pizza()
        {
            Purchases = new List<Purchase>();
            Carts = new List<Cart>();
        }

       

    }

}