using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Knjigas = new HashSet<Knjiga>();
        }

        public int Idautor { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }

        public virtual ICollection<Knjiga> Knjigas { get; set; }
    }
}
