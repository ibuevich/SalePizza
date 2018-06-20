using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalePizza.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public double Diameter { get; set; }
        [Required]
        public string Composition { get; set; }
    }
}