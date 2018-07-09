using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalePizza.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }

        public Cart()
        {
            Pizzas = new List<Pizza>();
        }

        [Range(0.0, Double.MaxValue)] //поискать в флюент
        public int AverageCost { get; set; }
    }
}