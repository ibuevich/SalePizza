using System.ComponentModel.DataAnnotations;

namespace SalePizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Diameter { get; set; }

        public string Composition { get; set; }
    }

}