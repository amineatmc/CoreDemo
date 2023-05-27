using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            //ViewBag.v1 = bm.GetAll().Count();
            ViewBag.v2 = c.Blogs.OrderByDescending(x => x.BlogID).Select(x=>x.Title).Take(1).FirstOrDefault();
            ViewBag.v3 = c.Comments.Count();
            return View();
        }
    }
}
