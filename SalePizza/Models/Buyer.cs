using System.ComponentModel.DataAnnotations;

namespace SalePizza.Models
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        //public Purchase Purchase { get; set; }
    }
}