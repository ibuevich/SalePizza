using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalePizza.Models
{
    public class Buyer
    {
        public int Id { get; set; }

        public string Adress { get; set; }

        //public string IdApplicationUser { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }

        public int PurchaseId { get; set; }

        public Purchase Purchase { get; set; }
    }
}