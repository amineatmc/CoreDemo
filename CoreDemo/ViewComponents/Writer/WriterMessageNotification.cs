using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mn = new MessageManager(new EfMessageRepository());
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            int writerID=Convert.ToInt32(c.Users.Where(x=>x.UserName == userName).Select(x=>x.Id).FirstOrDefault());
            var values = mn.GetInboxLİstByWriter(writerID);
            ViewBag.v = values.Count;
            return View(values);
        }
    }
}
