using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
