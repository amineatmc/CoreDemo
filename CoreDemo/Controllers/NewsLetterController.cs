using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {

        NewsLetterManager nm = new NewsLetterManager(new EfNewsLatterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p)
        {
            p.Status = true;
            nm.AddNewsLetter(p);
            return RedirectToAction("Index", "Blog");
        }


    }
}
