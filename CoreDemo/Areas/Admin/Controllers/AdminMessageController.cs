using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        [AllowAnonymous]
        [Area("Admin")]
        public IActionResult InBox()
        {
            return View();
        }
    }
}
