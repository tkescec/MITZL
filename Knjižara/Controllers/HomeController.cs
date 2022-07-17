using Knjižara.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.PosudbaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.RacunAccess;
using PRAPristupBazi.Models;
using RestSharp;
using System.Diagnostics;

namespace Knjižara.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var preporuceneKnjige = KnjigaAccess.DohvatiSveKnjige(Db, 0, 3);
            homeViewModel.preporuceneKnjige = (IList<PRAPristupBazi.Models.Knjiga>)preporuceneKnjige;
            
            return View(homeViewModel);
        }

        [HttpGet("/kosarica")]
        public IActionResult Kosarica()
        {


            KosaricaViewModel model = new KosaricaViewModel();

            return View();
        }
        [HttpPost("/naplati")]
        public bool? Naplati([FromBody] KosaricaRequestBody kosaricaRequestBody)
        {
            var userId = HttpContext.Session.GetInt32("_UserId");
            if (kosaricaRequestBody.kupnja == null || kosaricaRequestBody.posudba == null || userId == null) return null;
            IList<Stavka> knjige = kosaricaRequestBody.kupnja.Select(v => new Stavka { KnjigaId = int.Parse(v) }).ToList();
            IList<Posudba> posudbe = kosaricaRequestBody.posudba.Select(v => new Posudba
            {
                DatumPosudbe = DateTime.Now,
                KnjigaId = int.Parse(v),
                KorisnikId = userId,
                ZakasninaPoDanuId = 1,
                DatumVracanja = DateTime.Now.AddDays(21)
            }).ToList();
            try
            {
                if (posudbe != null)
                    foreach (var item in posudbe)
                    {
                        PosudbaAccess.DodajPosudbu(Db, item);
                    }
                Racun racun = new Racun { DatumIzdavanja = DateTime.Now, KorisnikId = userId, Stavkas = knjige };
                RacunAccess.DodajRacun(Db, racun);

            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}