using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Create() => View(); //{ return yerine =>}

        [HttpPost]
        public IActionResult Create(string name)
        {

        }
       
    }
}
