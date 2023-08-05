using Identity.Models;
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
                //herşey yolundaysa artık veritabanıma kaydedebilirim
                AppUser appUser = new AppUser() { Email=dto.Mail, UserName=dto.UserName};
            }
            return View(dto);
        }
    }
}
