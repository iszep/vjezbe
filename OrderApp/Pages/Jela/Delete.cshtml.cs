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
    public class DeleteModel : PageModel
    {
        private readonly OrderApp.Data.OrderAppContext _context;

        public DeleteModel(OrderApp.Data.OrderAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jelo = await _context.Jelo.FindAsync(id);

            if (Jelo != null)
            {
                _context.Jelo.Remove(Jelo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
