using System;
using System.ComponentModel.DataAnnotations;

namespace SalePizza.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        //[ForeignKey("PizzaId")]
        public int PizzaId { get; set; }

        //public Pizza Pizza { get; set; }

        //[ForeignKey("BuyerId")]
        [Required]
        public int BuyerId { get; set; }

        //public Buyer Buyer { get; set; }

        //public ICollection<Pizza> Pizzas { get; set; }
        //public Purchase()
        //{
        //    Pizzas = new List<Pizza>();
        //}
    }
}