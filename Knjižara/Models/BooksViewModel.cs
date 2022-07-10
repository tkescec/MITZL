using PRAPristupBazi.Models;
using System.ComponentModel.DataAnnotations;

namespace Knjižara.Models
{
    public class BooksViewModel
    {
        public IList<Knjiga> knjige = new List<Knjiga>();
        public int UkupniBrojKnjiga;
        public int offset;
        public int currentPage;
        public int? prevPage;
        public int? nextPage;
        public string? queryString;
        public void setCurrentPage(int currentPage)
        {
            this.currentPage = currentPage;
            if (currentPage != 1)
            {
                prevPage = currentPage - 1;
            }
            if (UkupniBrojKnjiga != 0 && currentPage != UkupniBrojKnjiga)
            {
                nextPage = currentPage + 1;
            }
        }
        public void addQueryString(string? value, string? searchBy)
        {
            if (value != null)
            {
                queryString = $"search={value}{(searchBy == null ? "" : $"&searchBy={searchBy}")}";
            }
        }

    }
}
