﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class Jelo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        [NotMapped]
        public int NarucenaKolicina { get; set; }
    }
}
