using System;
using System.Collections.Generic;

namespace SalePizza.Models
{
    public class Purchase
    {

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        public double Price { get; set; }

        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }


        public Purchase()
        {
            Pizzas = new List<Pizza>();
        }

    }
}