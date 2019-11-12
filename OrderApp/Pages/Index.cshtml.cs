using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApp.Data;
using OrderApp.Models;
using OrderApp.Extensions;
using Microsoft.AspNetCore.Http;

namespace OrderApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly OrderAppContext _context;
        public IList<Jelo> Jela { get; set; }
        public decimal Iznos { get; set; }
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, OrderAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Jela = _context.Jelo.ToList();
            GetCart();
        }

        public void OnPostNaruciGa(int id)
        {
            Jela = _context.Jelo.ToList();         
            var cart = GetCart();
            AddToCart(id, cart);
            GetCart();
            RedirectToPage();
        }

        private Cart GetCart()
        {
            Iznos = 0;
            Cart cart = new Cart();
            if (HttpContext.Session.Get<Cart>("Cart") != null)
            {
                cart = HttpContext.Session.Get<Cart>("Cart");
            }

            if (HttpContext.Session.Get<string>("Message") != null)
            {
                Message = HttpContext.Session.Get<string>("Message");
            }

            foreach (var jelo in Jela)
            {
                var found = cart.CartItems.Where(x => x.JeloId == jelo.Id).FirstOrDefault();
                if (found != null)
                {
                    jelo.NarucenaKolicina = found.Kolicina;
                    Iznos += found.Kolicina * jelo.Cijena;
                }
            }
            return cart;
        }

        private void AddToCart(int id, Cart cart)
        {
            var jelo = Jela.Where(x => x.Id == id).FirstOrDefault();
            var item = cart.CartItems.Where(x => x.JeloId == id).FirstOrDefault();
            if (item == null)
            {
                item = new CartItem { JeloId = id, Kolicina = 1, Cijena = jelo.Cijena, Naziv = jelo.Naziv };
                cart.CartItems.Add(item);
            }
            else
            {
                item.Kolicina++;
            }
            HttpContext.Session.Set<Cart>("Cart", cart);
        }
    }
}
