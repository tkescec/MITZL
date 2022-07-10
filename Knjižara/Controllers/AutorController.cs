using Knjižara.Models;
using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.AutorAccess;

namespace Knjižara.Controllers
{
    public class AutorController : BaseController
    {
        [HttpGet("/autor/{id}")]
        public IActionResult Index(int id)
        {
            if(id==null || id<=0) return Redirect("/");
            AutorViewModel autorViewModel = new AutorViewModel();
            autorViewModel.autor = AutorAccess.DohvatiAutoraPoIDu(Db, id);
            return View(autorViewModel);
        }
    }
}
