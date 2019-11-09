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
    public class IndexModel : PageModel
    {
        private readonly OrderAppContext _context;
        public string Valuta = "$";
        public string DugmeBrisi = "Formatiraj";

        public IndexModel(OrderAppContext context)
        {
            _context = context;
        }

        public IList<Jelo> Jela { get;set; }

        public async Task OnGetAsync()
        {
            Jela = await _context.Jelo.ToListAsync();
        }

        
    }
}
