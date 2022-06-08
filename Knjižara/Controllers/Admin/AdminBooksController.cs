using Microsoft.AspNetCore.Mvc;

namespace Knjižara.Controllers.Admin
{
    public class AdminBooksController : AdminBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
