using System;
using System.Collections.Generic;

namespace PRAPristupBazi.Models
{
    public partial class ZakasninaPoDanu
    {
        public ZakasninaPoDanu()
        {
            Posudbas = new HashSet<Posudba>();
        }

        public int IdzakasninaPoDanu { get; set; }
        public decimal? Zakasnina { get; set; }

        public virtual ICollection<Posudba> Posudbas { get; set; }
    }
}
