using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Posudba
    {
        public int Idposudba { get; set; }
        public int? KnjigaId { get; set; }
        public int? KorisnikId { get; set; }
        public int? ZakasninaPoDanuId { get; set; }
        public DateTime? DatumPosudbe { get; set; }
        public DateTime? PeriodPosudbe { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public bool? Kupljeno { get; set; }

        public virtual Knjiga? Knjiga { get; set; }
        public virtual Korisnik? Korisnik { get; set; }
        public virtual ZakasninaPoDanu? ZakasninaPoDanu { get; set; }
    }
}
