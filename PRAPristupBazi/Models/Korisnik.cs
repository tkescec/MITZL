using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Posudbas = new HashSet<Posudba>();
            Racuns = new HashSet<Racun>();
        }

        public int Idkorisnik { get; set; }
        public int? OsobaId { get; set; }
        public int? UlogaUaplikacijiId { get; set; }
        public string? Lozinka { get; set; }
        public string? SifraKorisnika { get; set; }
        public bool? Aktiviran { get; set; }
        public DateTime? DatumRegistracije { get; set; }
        public DateTime? DatumBrisanja { get; set; }

        public virtual Osoba? Osoba { get; set; }
        public virtual UlogaUaplikaciji? UlogaUaplikaciji { get; set; }
        public virtual ICollection<Posudba> Posudbas { get; set; }
        public virtual ICollection<Racun> Racuns { get; set; }
    }
}
