using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderApp.Data;
using OrderApp.Models;

namespace OrderApp.Pages.Narudzbe
{
    public class IndexModel : PageModel
    {
        private readonly OrderAppContext _context;

        public IndexModel(OrderAppContext context)
        {
            _context = context;
        }

        public IList<Cart> Carts { get;set; }

        public async Task OnGetAsync()
        {
            Carts = await _context.Cart.OrderByDescending(d => d.Datum).Include(c => c.CartItems).ToListAsync();
        }
    }
}
