using PRAPristupBazi.Models;

namespace Knjižara.Models
{
    public class BookViewModel
    {
        public Knjiga knjiga = new Knjiga { Autor=new Autor()};
        public IList<Knjiga> preporuceneKnjige = new List<Knjiga>();
    }
}
