using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderApp.Data;
using OrderApp.Models;

namespace OrderApp.Pages.Jela
{
    public class CreateModel : PageModel
    {
        private readonly OrderApp.Data.OrderAppContext _context;

        public CreateModel(OrderApp.Data.OrderAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Jelo Jelo { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jelo.Add(Jelo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
