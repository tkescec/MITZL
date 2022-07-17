using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Osobas = new HashSet<Osoba>();
        }

        public int Idgrad { get; set; }
        public int? DrzavaId { get; set; }
        public string? Naziv { get; set; }

        public virtual Drzava? Drzava { get; set; }
        public virtual ICollection<Osoba> Osobas { get; set; }
    }
}
