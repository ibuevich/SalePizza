using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalePizza.Models
{
    public class Buyer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        //public virtual ICollection<Purchase> Purchases { get; set; }

        //public Buyer()
        //{
        //    Purchases = new List<Purchase>();
        //}
    }
}