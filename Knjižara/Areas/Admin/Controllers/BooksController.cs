using Knjižara.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.AutorAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.IzdavacAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.PosudbaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StanjeKnjigeAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Areas.Admin.Controllers
{
    public class BooksController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            IList<Knjiga> knjige = new List<Knjiga>();

            try
            {
                knjige = KnjigaAccess.DohvatiSveKnjige(Db).ToList();
            }
            catch (Exception)
            {
                ViewBag.Error = "Došlo je do pogreške!";
            }

            ViewBag.Success = false;
            GetTempData();

            return View(knjige);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookViewModel model = new BookViewModel();

            try
            {
                model.Autori = AutorAccess.DohvatiAutore(Db).ToList();
                model.Izdavaci = IzdavacAccess.DohvatiIzdavace(Db).ToList();
                model.StanjaKnjige = StanjeKnjigeAccess.DohvatiStanjaKnjige(Db).ToList();
            }
            catch (Exception)
            {
                ViewBag.Error = "Došlo je do pogreške!";
            }

            ViewBag.Success = false;
            GetTempData();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Knjiga knjiga = new Knjiga(); 

            try
            {
                CopyPropertyValues(model, knjiga);
                KnjigaAccess.DodajKnjigu(Db, knjiga);

                TempData["Success"] = true;
            }
            catch (Exception)
            {
                TempData["Error"] = "Došlo je do pogreške!";
            }

            return RedirectToLocal(returnUrl);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            BookViewModel model = new BookViewModel();

            try
            {
                Knjiga knjiga = KnjigaAccess.DohvatiKnjigu(Db, id);
                CopyPropertyValues(knjiga, model);
                model.Autori = AutorAccess.DohvatiAutore(Db).ToList();
                model.Izdavaci = IzdavacAccess.DohvatiIzdavace(Db).ToList();
                model.StanjaKnjige = StanjeKnjigeAccess.DohvatiStanjaKnjige(Db).ToList();
            }
            catch (Exception)
            {
                ViewBag.Error = "Došlo je do pogreške!";
            }

            ViewBag.Success = false;
            GetTempData();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Knjiga knjiga = new Knjiga();

            try
            {
                CopyPropertyValues(model, knjiga);
                KnjigaAccess.AzurirajKnjigu(Db, knjiga);

                TempData["Success"] = true;
            }
            catch (Exception)
            {
                TempData["Error"] = "Došlo je do pogreške!";
            }

            return RedirectToLocal(returnUrl);
        }

        [HttpGet]
        public IActionResult Deleted()
        {
            IList<Knjiga> knjige = new List<Knjiga>();

            try
            {
                knjige = KnjigaAccess.DohvatiIzbrisaneKnjige(Db).ToList();
            }
            catch (Exception)
            {
                ViewBag.Error = "Došlo je do pogreške!";
            }

            ViewBag.Success = false;
            GetTempData();

            return View(knjige);
        }

        [HttpPut]
        public IActionResult Restore(int id)
        {
            object jsonData;

            try
            {
                Knjiga knjiga = KnjigaAccess.DohvatiKnjigu(Db, id);

                if (knjiga != null)
                {
                    KnjigaAccess.PovratiKnjigu(Db, knjiga);

                    TempData["Success"] = true;
                    TempData["Message"] = "Knjiga je uspješno obnovljena!";
                    jsonData = new { success = true, returnUrl = "/Admin/Books/Deleted" };
                }
                else
                {
                    TempData["Error"] = "Nepostojeća knjiga!";
                    jsonData = new { success = false };
                }

            }
            catch (Exception)
            {
                TempData["Error"] = "Došlo je do pogreške!";
                jsonData = new { success = false };
            }

            return Json(jsonData);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            object jsonData;

            try
            {
                Knjiga knjiga = KnjigaAccess.DohvatiKnjigu(Db, id);

                if (knjiga != null)
                {
                    KnjigaAccess.IzbrisiKnjigu(Db, knjiga);

                    TempData["Success"] = true;
                    TempData["Message"] = "Knjiga je uspješno izbrisana!";
                    jsonData = new { success = true, returnUrl = "/Admin/Books" };
                }
                else
                {
                    TempData["Error"] = "Nepostojeća knjiga!";
                    jsonData = new { success = false };
                }
            
            }
            catch (Exception)
            {
                TempData["Error"] = "Došlo je do pogreške!";
                jsonData = new { success = false };
            }

            return Json(jsonData);
        }

        [HttpGet]
        public IActionResult Borrowed()
        {
            IList<Posudba> posudbe = new List<Posudba>();

            try
            {
                posudbe = PosudbaAccess.DohvatiSvePosudbe(Db).ToList();
            }
            catch (Exception)
            {
                ViewBag.Error = "Došlo je do pogreške!";
            }

            ViewBag.Success = false;
            GetTempData();

            return View(posudbe);
        }

        [HttpPut]
        public IActionResult Return(int id)
        {
            object jsonData;

            try
            {
                Posudba posudba = PosudbaAccess.DohvatiPosudbu(Db, id);

                if (posudba != null)
                {
                    posudba.DatumVracanja = DateTime.Now;
                    PosudbaAccess.AzurirajPosudbu(Db, posudba);

                    TempData["Success"] = true;
                    TempData["Message"] = "Knjiga je uspješno vraćena!";
                    jsonData = new { success = true, returnUrl = "/Admin/Books/Borrowed" };
                }
                else
                {
                    TempData["Error"] = "Nepostojeća posudba!";
                    jsonData = new { success = false };
                }

            }
            catch (Exception)
            {
                TempData["Error"] = "Došlo je do pogreške!";
                jsonData = new { success = false };
            }

            return Json(jsonData);
        }
    }
}
