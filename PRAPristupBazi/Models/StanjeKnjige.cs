using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class StanjeKnjige
    {
        public StanjeKnjige()
        {
            Knjigas = new HashSet<Knjiga>();
        }

        public int IdstanjeKnjige { get; set; }
        public string? Stanje { get; set; }

        public virtual ICollection<Knjiga> Knjigas { get; set; }
    }
}
