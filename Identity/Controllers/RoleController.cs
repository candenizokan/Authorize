using Identity.Models;
using Identity.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Create() => View(); //{ return yerine =>}

        [HttpPost]
        public async Task<IActionResult> Create([Required(ErrorMessage = "İsim Boş olamaz")][MinLength(3, ErrorMessage = "En az 3 karakter yazmalısınız")] string name)
        {
            if (ModelState.IsValid)
            {
                //db ye di ile enjeksiyonla gelen _roleManager ile kayıt yapacağım.
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole() { Name = name });// CreateAsync benden IdentityRole nesnesi istiyor. bende IdentityRole nesnesi oluşturup ekliyorum. burası benden bir result dönüyor. 
                if (result.Succeeded) return RedirectToAction("List");//başarılıysa db ye ekledim demektir liste götür diyorum
            }
            return View();
        }

        public IActionResult List() => View(_roleManager.Roles);


        public async Task<IActionResult> AssignUser(string id) 
        {
            IdentityRole identityRole = await _roleManager.FindByIdAsync(id);//yukarda id si olan rolü bulmak istiyorum

            //benim role sahip olanlarımın listesi
            List<AppUser> hasRole = new List<AppUser>();
            List<AppUser> hasNotRole = new List<AppUser>();

            //sahip olduğum tüm kullanıcıları çağımam için usermanager sınıfına ihtiyacım var. bunu ctorda di ile alacağım

            foreach (var item in _userManager.Users)
            {
                var list = (await _userManager.IsInRoleAsync(item, identityRole.Name)) ? hasRole : hasNotRole;
                list.Add(item);
            }

            AssignVM
            
        }
    }
}
