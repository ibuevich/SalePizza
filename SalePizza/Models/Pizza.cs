using System.ComponentModel.DataAnnotations;

namespace SalePizza.Models
{
    public class Pizza
    {
        [Key] public int Id { get; set; }
        [Required] [MaxLength(40)] public string Name { get; set; }
        public double Diameter { get; set; }
        [Required] public string Composition { get; set; }

        //public Purchase Purchase { get; set; }
    }

}