using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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

        public Pizza Pizza { get; set; }

        //[ForeignKey("BuerId")]
        [Required]
        public int BuerId { get; set; }

        public Buer Buer { get; set; }
    }
}