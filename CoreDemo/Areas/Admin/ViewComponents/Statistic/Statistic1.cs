using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 :ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c= new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetAll().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string api = "448988b878f023d5978436ba9d6ee28a";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument documant= XDocument.Load(connection);
            ViewBag.v4=documant.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
