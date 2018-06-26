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

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public Pizza()
        {
            Purchases = new List<Purchase>();
        }
    }

}