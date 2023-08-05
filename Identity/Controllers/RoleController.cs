using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
