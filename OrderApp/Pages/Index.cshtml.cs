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

namespace OrderApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly OrderAppContext _context;
        public IList<Jelo> Jela { get; set; }

        public IndexModel(ILogger<IndexModel> logger, OrderAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Jela =  _context.Jelo.ToList();
        }

        public IActionResult OnPostNaruci()
        {
            var x = 1;
            return Page();
        }
    }
}
