using Knjižara.Models;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                Korisnik user = KorisnikAccess.AutentificirajKorisnika(Db, model.Email, model.Password);

                returnUrl = user.UlogaUaplikacijiId switch
                {
                    1 => "/",
                    _ => "/Admin/Books",
                };

                if (user.Aktiviran != null && user.DatumBrisanja == null)
                {
                    string userName = user.Osoba?.Ime?.ToString() + " " + user.Osoba?.Prezime?.ToString();

                    HttpContext.Session.SetInt32("_UserId", user.Idkorisnik);
                    HttpContext.Session.SetInt32("_UserRole", user.UlogaUaplikaciji.IdulogaUaplikaciji);
                    HttpContext.Session.SetString("_UserName", userName);

                    return RedirectToLocal(returnUrl);
                }                

                ModelState.AddModelError("", "Korisnički račun nije aktivan!");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Neispravna email adresa i/ili lozinka!");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
