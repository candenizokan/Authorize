using Identity.Models;
using Identity.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (ModelState.IsValid)// validasyonlarım tamam mı
            {
                //herşey yolundaysa artık veritabanıma kaydedebilirim
                AppUser appUser = new AppUser() { Email = dto.Mail, UserName = dto.UserName };
                IdentityResult result = await _userManager.CreateAsync(appUser, dto.Password);
            }
            return View(dto);
        }
    }
}
