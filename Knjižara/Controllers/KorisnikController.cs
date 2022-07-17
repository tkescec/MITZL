using Knjižara.Models;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.RacunAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Controllers
{
    public class KorisnikController : BaseController
    {
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("_UserId");
            if (userId == null) return Redirect("/");
            KorisnikViewModel korisnikViewModel = new KorisnikViewModel();
            korisnikViewModel.korisnik = KorisnikAccess.DohvatiJednogKorisnika(Db, (int)userId);
            korisnikViewModel.posljednjeKupnje = (IList<PRAPristupBazi.Models.Racun>)RacunAccess.DohvatiSveRacunePoKorisniku(Db, korisnikViewModel.korisnik);
            return View(korisnikViewModel);
        }

        public IActionResult Uredi()
        {
            var userId = HttpContext.Session.GetInt32("_UserId");
            if (userId == null) return Redirect("/");
            Korisnik korisnik = KorisnikAccess.DohvatiJednogKorisnika(Db, (int)userId);
            EditKorisnikViewModel editKorisnikViewModel = new EditKorisnikViewModel
            {
                Address=korisnik.Osoba!=null? korisnik.Osoba.Adresa:"", City= korisnik.Osoba.Grad != null ? korisnik.Osoba.Grad.Naziv:"", Name=korisnik.Osoba.Ime, Country = korisnik.Osoba.Grad.Drzava==null?"": korisnik.Osoba.Grad.Drzava.Naziv,
                LastName = korisnik.Osoba.Prezime, PostalCode=korisnik.Osoba.PostanskiBroj
            };
            
            return View(editKorisnikViewModel);
        }

        [HttpPost]
        public IActionResult Uredi(EditKorisnikViewModel model)
        {
            var userId = HttpContext.Session.GetInt32("_UserId");
            if (userId == null) return Redirect("/");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                Korisnik korisnik = new Korisnik
                {Idkorisnik= (int)userId,
                    Osoba = new Osoba
                    {
                        Adresa = model.Address,
                        Grad = new Grad { Naziv = model.City },
                        Ime = model.Name,
                        Prezime = model.LastName,
                        PostanskiBroj = model.PostalCode
                    },
                    Lozinka = model.Password,
                };

                KorisnikAccess.AzurirajKorisnika(Db, korisnik, model.Password==model.PasswordSecond);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Došlo je do pogreške!");
            }
            return Redirect("/");

        }
    }
}
