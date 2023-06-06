using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
  
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values = bm.BlogListGetById(id);
            return View(values);
        }
        
        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            //var userName = User.Identity.Name;
            //var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            //var writerID = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterID).FirstOrDefault();
            int writerID= Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values=bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();
            ViewBag.cv=categoryValue;
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (results.IsValid)
            {
                p.Status = true;
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult DeleteBlog(int id)
        {
            var blogValue=bm.TGetById(id);
            bm.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id) 
        {
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            var blogValue=bm.TGetById(id);
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var blogValue = bm.TGetById(p.BlogID);
            p.CreateDate = blogValue.CreateDate;
            p.Status = blogValue.Status;
            p.WriterID = writerID;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
