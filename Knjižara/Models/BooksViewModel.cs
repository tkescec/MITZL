using PRAPristupBazi.Models;
using System.ComponentModel.DataAnnotations;

namespace Knjižara.Models
{
    public class BooksViewModel
    {
        public IList<Knjiga> knjige = new List<Knjiga>(); 
            
        
    }
}
