using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Knjiga
    {
        public Knjiga()
        {
            Posudbas = new HashSet<Posudba>();
            Stavkas = new HashSet<Stavka>();
        }

        public int Idknjiga { get; set; }
        public int? AutorId { get; set; }
        public int? IzdavacId { get; set; }
        public int? StanjeKnjigeId { get; set; }
        public string? Naslov { get; set; }
        public string? Izdanje { get; set; }
        public string? KratakSadrzaj { get; set; }
        public string? Slika { get; set; }
        public int? DostupnaKolicina { get; set; }
        public decimal? CijenaZaKupovinu { get; set; }
        public decimal? CijenaZaNajam { get; set; }
        public long? Popularnost { get; set; }
        public DateTime? DatumDodavanja { get; set; }
        public DateTime? DatumBrisanja { get; set; }

        public virtual Autor? Autor { get; set; }
        public virtual Izdavac? Izdavac { get; set; }
        public virtual StanjeKnjige? StanjeKnjige { get; set; }
        public virtual ICollection<Posudba> Posudbas { get; set; }
        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}
