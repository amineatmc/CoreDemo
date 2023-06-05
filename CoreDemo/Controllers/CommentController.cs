using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        BlogManager bm= new BlogManager(new EfBlogRepository());
        BlogController bc = new BlogController();
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult ParitalAddComment()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ParitalAddComment(Comment p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            cm.Add(p);
            return RedirectToAction("Index","Blog");
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            ViewBag.vBlogID = id;
            var values=cm.GetList(id);
            return PartialView(values);
            
        }
    }
}
