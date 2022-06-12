using Knjižara.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl = "/Admin/Books")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                Korisnik user = KorisnikAccess.AutentificirajKorisnika(Db, model.Email, model.Password);

                return RedirectToLocal(returnUrl);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Neispravna email adresa i/ili lozinka");
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
    }
}
