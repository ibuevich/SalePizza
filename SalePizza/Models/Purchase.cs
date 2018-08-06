using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SalePizza.Models
{
    public class Purchase
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[Display(Name = "Город")]
        public string Town { get; set; }

        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        //[Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дом")]
        public string House { get; set; }

        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[Range(0, 5000, ErrorMessage = "Недопустимый номер квартиры")]
        //[Display(Name = "Квартира")]
        public int Apartmen { get; set; }

        //[Range(0.0, Double.MaxValue)]
        //[Display(Name = "Результирующая цена")]
        public double Price { get; set; }

        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }


        public Purchase()
        {
            Pizzas = new List<Pizza>();
        }

    }
}