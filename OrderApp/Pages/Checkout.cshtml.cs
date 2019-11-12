using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderApp.Models;
using OrderApp.Extensions;
using OrderApp.Data;

namespace OrderApp.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public Cart Cart { get; set; }
        [BindProperty]
        public string Kupac { get; set; }
        [BindProperty]
        public string Adresa { get; set; }
        [BindProperty]
        public string Telefon { get; set; }
        public string ErrorMessage { get; set; }
        public decimal Ukupno { get; set; }
        private readonly OrderAppContext _context;

        public CheckoutModel(OrderAppContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Cart = new Cart();
            if (HttpContext.Session.Get<Cart>("Cart") != null)
            {
                Cart = HttpContext.Session.Get<Cart>("Cart");
            }

            foreach(var item in Cart.CartItems)
            {
                Ukupno += item.Kolicina * item.Cijena;
            }
        }

        public IActionResult OnPostNaruci()
        {

            Cart = new Cart();
            if (HttpContext.Session.Get<Cart>("Cart") != null)
            {
                Cart = HttpContext.Session.Get<Cart>("Cart");
            }

            foreach (var item in Cart.CartItems)
            {
                Ukupno += item.Kolicina * item.Cijena;
            }

            if (Kupac == null || Adresa == null || Telefon == null || Cart.CartItems.Count == 0)
            {
                ErrorMessage = "Niste popunili sve potrebne podatke!";
                HttpContext.Session.Remove("Message");
              
                return Page();
            }
            Cart.Kupac = Kupac;
            Cart.Telefon = Telefon;
            Cart.Adresa = Adresa;
            Cart.Datum = DateTime.Now;
            Cart.Iznos = Ukupno;
            _context.Add(Cart);
            _context.SaveChanges();
            HttpContext.Session.Remove("Cart");
            HttpContext.Session.Set<string>("Message", "Uspješno ste izvršili narudžbu!");
            return RedirectToPage("/Index");
        }
    }
}