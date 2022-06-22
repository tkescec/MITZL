using Knjižara.Mailer;
using Knjižara.Mailer.Models;
using Knjižara.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.OsobaAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IEmailService mailService;
        public AccountController(IEmailService mailService)
        {
            this.mailService = mailService;
        }

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

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Korisnik korisnik = new Korisnik { 
            Osoba = new Osoba { Adresa=model.Address, Email=model.Email, Grad= new Grad { Naziv= model.City}, 
            Ime=model.FirstName, Prezime=model.LastName, PostanskiBroj=model.PostalCode
            }, Lozinka = model.Password, UlogaUaplikacijiId=1
            };
            try
            {
               string korisnikAppID = KorisnikAccess.DodajKorisnika(Db, korisnik);
                MailRequest request = new MailRequest { ToEmail = korisnik.Osoba.Email };
                // kontroler treba tek implementirat
                string magicLink = $"{Request.Scheme}://{Request.Host}/api/login/verify?SifraKorisnika={korisnik.SifraKorisnika}";
                await mailService.SendMagicLink(request, magicLink);
                

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Došlo je do pogreške!");
            }

            return View(model);
        }
    }
}
