﻿using Knjižara.Models;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;

namespace Knjižara.Controllers
{
    public class BooksController : BaseController
    {
        private int limit = 12;
        public IActionResult Index([FromQuery(Name = "page")] int? page, [FromQuery(Name = "search")] string? search, [FromQuery(Name = "searchBy")] string? searchBy)
        {
            BooksViewModel booksViewModel = new BooksViewModel();
            booksViewModel.setCurrentPage((int)(page == null ? 1 : page));
            booksViewModel.offset = (booksViewModel.currentPage - 1) * limit;
            booksViewModel.addQueryString(search, searchBy);
            try
            {
                booksViewModel.knjige = (IList<PRAPristupBazi.Models.Knjiga>)(search == null ?
                     KnjigaAccess.DohvatiSveKnjige(Db, booksViewModel.offset, limit)
                    :(searchBy!=null?KnjigaAccess.DohvatiKnjigePoAutoru(Db, search, booksViewModel.offset, limit) : KnjigaAccess.DohvatiKnjigePoNaslovu(Db, search, booksViewModel.offset, limit)));
                booksViewModel.UkupniBrojKnjiga = search == null ? KnjigaAccess.DohvatiBrojKnjiga(Db) : KnjigaAccess.DohvatiBrojKnjigaPoNaslovuIliAutoru(Db, search, searchBy);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(booksViewModel);
        }

        public IActionResult Book(int id)
        {
            if (id == null || id < 0) Redirect("/");
            BookViewModel booksViewModel = new BookViewModel();
            try
            {
                var book = KnjigaAccess.DohvatiKnjiguPoIDu(Db, id);
                var preporuceneKnjige = KnjigaAccess.DohvatiSveKnjigeGdjeIDNije(Db, 0, 3, id);
                booksViewModel.knjiga = book;
                booksViewModel.preporuceneKnjige = (IList<PRAPristupBazi.Models.Knjiga>)preporuceneKnjige;
            }
            catch (Exception ex) { };
            return View(booksViewModel);
        }
    }
}
