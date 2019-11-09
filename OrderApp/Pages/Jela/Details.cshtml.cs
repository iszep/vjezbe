using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderApp.Data;
using OrderApp.Models;

namespace OrderApp.Pages.Jela
{
    public class DetailsModel : PageModel
    {
        private readonly OrderApp.Data.OrderAppContext _context;

        public DetailsModel(OrderApp.Data.OrderAppContext context)
        {
            _context = context;
        }

        public Jelo Jelo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jelo = await _context.Jelo.FirstOrDefaultAsync(m => m.Id == id);

            if (Jelo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
