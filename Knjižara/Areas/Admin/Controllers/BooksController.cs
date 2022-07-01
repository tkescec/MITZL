using Knjižara.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.AutorAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.IzdavacAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StanjeKnjigeAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Areas.Admin.Controllers
{
    public class BooksController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateBookViewModel model = new CreateBookViewModel();

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
        public IActionResult Create(CreateBookViewModel model, string returnUrl)
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
        public IActionResult Edit()
        {
            CreateBookViewModel viewModel = new CreateBookViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateBookViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Deleted()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Borrowed()
        {
            return View();
        }
    }
}
