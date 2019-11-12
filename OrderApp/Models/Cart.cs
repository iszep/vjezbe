using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Datum { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Iznos { get; set; }
        public string Kupac { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
     
    }
}
