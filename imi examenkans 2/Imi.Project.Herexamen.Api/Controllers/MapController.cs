using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Herexamen.Api.Controllers
{
    public class MapController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}