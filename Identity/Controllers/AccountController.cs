using Identity.Models;
using Identity.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Identity.Controllers
{
    [Authorize]//x bir kişinin buraya ulaşabilmesi için Authorize olması lazım.
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SignInManager<AppUser> _signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                //içerdeki use kim bulmaya çalışıyorum
                AppUser appUser = await _userManager.FindByNameAsync(dto.UserName); // kullanıcıyı bulması
                if (appUser!=null)//kullanıcım var mı varsa içeri gir şifre doğru mu
                {
                    //şifre kotrolü yapmam lazım. bunu başka bir sınıf yapıyor. bu durumda bunu di ile almam lazım.
                    SignInResult result= await _signInManager.PasswordSignInAsync(dto.UserName,dto.Password,false,false);//başarılı mı başarısız mı
                    if (result.Succeeded) //kullanıcı adı ve şifre doğru ise
                    {
                        return Redirect(dto.ReturnUrl ?? "/");//dto.ReturnUrl varsa oraya götür yoksa anasayfaya götür
                    }
                }
            }
            return View(dto);
        }
    }
}
