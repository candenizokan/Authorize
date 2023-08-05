using Identity.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO dto)
        {
            if (ModelState.IsValid)// validasyonlarım tamam mı
            {

            }
            return View(dto);
        }
    }
}
