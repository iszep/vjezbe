﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class Jelo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
    }
}
