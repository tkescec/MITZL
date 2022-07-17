using Knjižara.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjizaraAccess;
using PRAPristupBazi.Models;

namespace Knjižara.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public IActionResult Settings()
        {
            SettingsViewModel viewModel = new SettingsViewModel();

            try
            {
                Knjizara knjizara = KnjizaraAccess.DohvatiPodatkeOKnjizari(Db);
                CopyPropertyValues(knjizara, viewModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Došlo je do pogreške!");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Settings(SettingsViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Knjizara knjizara = new Knjizara();

            try
            {
                CopyPropertyValues(model, knjizara);
                KnjizaraAccess.AzurirajPodatkeOKnjizari(Db, knjizara);
                
                model.Success = true;
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Došlo je do pogreške!");
            }

            return View(model);
        }
    }
}
