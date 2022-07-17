using Knjižara.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            IList<Korisnik> korisnici = new List<Korisnik>();

            try
            {
                korisnici = KorisnikAccess.DohvatiSveKorisnike(Db).ToList();
            }
            catch (Exception)
            {
                ViewBag.Error = "Došlo je do pogreške!";
            }

            ViewBag.Success = false;
            GetTempData();

            return View(korisnici);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UserViewModel model = new UserViewModel();

            try
            {
                Korisnik korisnik = KorisnikAccess.DohvatiJednogKorisnika(Db, id);
                CopyPropertyValues(korisnik, model);
                model.Osoba = korisnik.Osoba;
                model.Posudbe = korisnik.Posudbas;
            }
            catch (Exception)
            {
                ViewBag.Error = "Došlo je do pogreške!";
            }

            ViewBag.Success = false;
            GetTempData();

            return View(model);
        }
    }
}
