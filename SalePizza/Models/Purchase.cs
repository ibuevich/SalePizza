using System;
using System.Collections.Generic;

namespace SalePizza.Models
{
    public class Purchase
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }

        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }

        public Purchase()
        {
            Pizzas = new List<Pizza>();
        }

    }
}