using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Osoba
    {
        public Osoba()
        {
            Korisniks = new HashSet<Korisnik>();
        }

        public int Idosoba { get; set; }
        public int? GradId { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Email { get; set; }
        public string? Adresa { get; set; }
        public string? PostanskiBroj { get; set; }

        public virtual Grad? Grad { get; set; }
        public virtual ICollection<Korisnik> Korisniks { get; set; }

        public override string? ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
