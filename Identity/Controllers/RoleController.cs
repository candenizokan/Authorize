using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Create() => View(); //{ return yerine =>}

        [HttpPost]
        public IActionResult Create([Required(ErrorMessage = "İsim Boş olamaz")][MinLength(3, ErrorMessage = "En az 3 karakter yazmalısınız")] string name)
        {
            if (ModelState.IsValid)
            {
                //db ye di ile enjeksiyonla gelen _roleManager ile kayıt yapacağım.
                _roleManager.CreateAsync(new IdentityRole() { Name = name });// CreateAsync benden IdentityRole nesnesi istiyor. bende IdentityRole nesnesi oluşturup ekliyorum. burası benden bir result dönüyor. 
            }
            return View();
        }
       
    }
}
