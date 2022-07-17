using PRAPristupBazi.Models;

namespace Knjižara.Models
{
    public class KosaricaViewModel
    {
       public IList<Knjiga> knjigeZaPosudbu = new List<Knjiga>();
       public IList<Knjiga> knjigeZaKupnju = new List<Knjiga>();
    }

    public class KosaricaRequestBody
    {
        public List<string>? posudba { set; get; }
        public List<string>? kupnja { set; get; }
    }
}
