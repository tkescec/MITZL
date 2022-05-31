using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Knjizara
    {
        public int Idknjizara { get; set; }
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? Oib { get; set; }
        public string? Iban { get; set; }
        public string? Logo { get; set; }
        public string? UvjetiKoristenja { get; set; }
    }
}
