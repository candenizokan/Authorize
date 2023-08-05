using Identity.Models;
using Identity.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [Authorize]//x bir kişinin buraya ulaşabilmesi için Authorize olması lazım.
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous] //registre actionu AllowAnonymous yapınca kimliğini tanıntmamış kişilerde gelebilir. yetkilendirilmemiş kişilerde gelebilir ilk defa geliyor kayıt olmak için o yüzden izin ver. loginde çök ensesine 
        public IActionResult Register()
        {
            return View();
        }
        //AllowAnonymous kimliği belirlenmemiş kişiler buraya gelebilir, Authorize kendini ezdirmez/etkilemez
        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (ModelState.IsValid)// validasyonlarım tamam mı
            {
                //herşey yolundaysa artık veritabanıma kaydedebilirim
                AppUser appUser = new AppUser() { Email = dto.Mail, UserName = dto.UserName };
                IdentityResult result = await _userManager.CreateAsync(appUser, dto.Password); //UserManager içindeki CreateAsync veritabanıma kaydediyor. IdentityResult ise create oldu mu olmadı mı diye kontrol ediyor
                if (result.Succeeded) return RedirectToAction("Login");
            }
            return View(dto);
        }

        public IActionResult Login(string returnUrl)
        {
            return View( new LoginDTO() { ReturnUrl=returnUrl});
        }

        [HttpPost]
        public IActionResult Login(LoginDTO dto)
        {
            return View();
        }
    }
}
