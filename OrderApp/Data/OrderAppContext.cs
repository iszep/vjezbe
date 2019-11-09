using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Models;

namespace OrderApp.Data
{
    public class OrderAppContext : DbContext
    {
        public OrderAppContext (DbContextOptions<OrderAppContext> options)
            : base(options)
        {
        }

        public DbSet<OrderApp.Models.Jelo> Jelo { get; set; }
    }
}
