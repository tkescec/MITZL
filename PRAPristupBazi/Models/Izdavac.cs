using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Izdavac
    {
        public Izdavac()
        {
            Knjigas = new HashSet<Knjiga>();
        }

        public int Idizdavac { get; set; }
        public string? Naziv { get; set; }

        public virtual ICollection<Knjiga> Knjigas { get; set; }
    }
}
