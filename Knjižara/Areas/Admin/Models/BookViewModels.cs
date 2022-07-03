using PRAPristupBazi.Models;
using System.ComponentModel.DataAnnotations;

namespace Knjižara.Areas.Admin.Models
{
    public class BaseBookViewModel
    {
        public int Idknjiga { get; set; }
        public DateTime? DatumDodavanja { get; set; }
        public virtual Autor? Autor { get; set; }
        public virtual Izdavac? Izdavac { get; set; }
        public virtual StanjeKnjige? StanjeKnjige { get; set; }

        public BaseBookViewModel()
        {
            DatumDodavanja = DateTime.Now;
        }
    }

    public class BookViewModel : BaseBookViewModel
    {
        [Required]
        public string? Naslov { get; set; }

        [Required]
        public int? AutorId { get; set; }

        [Required]
        public int? IzdavacId { get; set; }

        [Required]
        public int? DostupnaKolicina { get; set; }

        [Required]
        public decimal? CijenaZaKupovinu { get; set; }

        [Required]
        public decimal? CijenaZaNajam { get; set; }

        [Required]
        public int? StanjeKnjigeId { get; set; }

        [Required]
        public string? KratakSadrzaj { get; set; }

        [Required]
        public string? Slika { get; set; }

        public IList<Autor>? Autori { get; set; }
        public IList<Izdavac>? Izdavaci { get; set; }
        public IList<StanjeKnjige>? StanjaKnjige { get; set; }

    }
}
