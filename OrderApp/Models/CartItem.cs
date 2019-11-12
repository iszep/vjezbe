using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int JeloId { get; set; }
        public int CartId { get; set; }
        public string Naziv { get; set; }
        [Display(Name = "Količina")]
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
    }
}
