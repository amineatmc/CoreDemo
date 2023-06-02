using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();

		public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.v = userName;
            var userMail=c.Users.Where(x=>x.UserName==userName).Select(x=>x.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
