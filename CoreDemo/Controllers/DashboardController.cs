using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());


        [AllowAnonymous]
        public IActionResult Index()
        {
            Context cm = new Context();
            ViewBag.v1 = cm.Blogs.Count().ToString();
            ViewBag.v2 = cm.Blogs.Where(x=>x.WriterID==1).Count().ToString();
            ViewBag.v3=cm.Categories.Count().ToString();
            return View();
        }
    }
}
