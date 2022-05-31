using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Racun
    {
        public Racun()
        {
            Stavkas = new HashSet<Stavka>();
        }

        public int Idracun { get; set; }
        public int? KorisnikId { get; set; }
        public DateTime? DatumIzdavanja { get; set; }

        public virtual Korisnik? Korisnik { get; set; }
        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}
