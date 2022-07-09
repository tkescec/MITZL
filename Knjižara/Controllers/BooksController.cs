using Knjižara.Models;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;

namespace Knjižara.Controllers
{
    public class BooksController : BaseController
    {
        public IActionResult Index()
        {
            BooksViewModel booksViewModel = new BooksViewModel();
            try
            {
                booksViewModel.knjige = (IList<PRAPristupBazi.Models.Knjiga>)KnjigaAccess.DohvatiSveKnjige(Db);
            } catch(Exception ex)
            {
                Console.WriteLine(  ex);
            }
                return View(booksViewModel);
        }
    }
}
