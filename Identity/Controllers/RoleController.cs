using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Create() => View(); //{ return yerine =>}

        [HttpPost]
        public IActionResult Create([Required(ErrorMessage = "İsim Boş olamaz")][MinLength(3, ErrorMessage = "En az 3 karakter yazmalısınız")] string name)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
       
    }
}
