using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class UlogaUaplikaciji
    {
        public UlogaUaplikaciji()
        {
            Korisniks = new HashSet<Korisnik>();
        }

        public int IdulogaUaplikaciji { get; set; }
        public string? Uloga { get; set; }

        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
