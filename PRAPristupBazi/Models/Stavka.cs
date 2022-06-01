using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class Stavka
    {
        public int Idstavka { get; set; }
        public int? RacunId { get; set; }
        public int? KnjigaId { get; set; }

        public virtual Knjiga? Knjiga { get; set; }
        public virtual Racun? Racun { get; set; }
    }
}
