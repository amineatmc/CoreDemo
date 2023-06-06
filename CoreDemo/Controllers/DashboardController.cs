using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context cm = new Context();


        public IActionResult Index()
        {
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            ViewBag.v1 = cm.Blogs.Count().ToString();
            ViewBag.v2 = cm.Blogs.Where(x=>x.WriterID==writerID).Count().ToString();
            ViewBag.v3=cm.Categories.Count().ToString();
            return View();
        }
    }
}
