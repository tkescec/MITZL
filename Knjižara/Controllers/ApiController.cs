using Knjižara.Mailer;
using Knjižara.Mailer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : BaseController
    {
        private readonly IEmailService mailService;
        public ApiController(IEmailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request, "Registration");
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("/login/verify")]
        public async Task<IActionResult> GET([FromQuery(Name = "SifraKorisnika")] string sifra)
        {
            Korisnik user = KorisnikAccess.DohvatiKorisnikaPoSifri(Db, sifra);
            if (user.Aktiviran == false)
            {
                user.Aktiviran = true;
                KorisnikAccess.AzurirajKorisnika(Db, user, false);
                string userName = user.Osoba?.Ime?.ToString() + " " + user.Osoba?.Prezime?.ToString();

                HttpContext.Session.SetInt32("_UserId", user.Idkorisnik);
                HttpContext.Session.SetInt32("_UserRole", user.UlogaUaplikaciji.IdulogaUaplikaciji);
                HttpContext.Session.SetString("_UserName", userName);
            }
            return Redirect("/");
        }


    }
}
