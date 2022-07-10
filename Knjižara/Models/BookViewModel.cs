using PRAPristupBazi.Models;

namespace Knjižara.Models
{
    public class BookViewModel
    {
        public Knjiga knjiga = new Knjiga();
        public IList<Knjiga> preporuceneKnjige = new List<Knjiga>();
    }
}
