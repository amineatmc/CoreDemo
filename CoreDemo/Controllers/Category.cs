using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class Category : Controller
    {
        CategoryManager cm= new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
