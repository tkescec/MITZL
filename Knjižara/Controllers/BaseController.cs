using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL;
using PRAPristupBazi.DAL.DatabaseAccess;

namespace Knjižara.Controllers
{
    public class BaseController : Controller
    {
        private KnjizaraContext db = DBConnectionPool.GetDBConnection();

        internal KnjizaraContext Db { get => db; set => db = value; }

        internal void GetTempData()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
                TempData["Message"] = null;
            }
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                TempData["Error"] = null;
            }
        }

        internal IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
