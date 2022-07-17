using PRAPristupBazi.Models;

namespace Knjižara.Areas.Admin.Models
{
    public class BaseUserViewModel
    {
        public int Idkorisnik { get; set; }
        public Osoba? Osoba { get; set; }
    }

    public class UserViewModel : BaseUserViewModel
    {
        public ICollection<Posudba> Posudbe { get; set; }

        public override string? ToString()
        {
            return Osoba.Ime + " " + Osoba.Prezime;
        }
    }
}
