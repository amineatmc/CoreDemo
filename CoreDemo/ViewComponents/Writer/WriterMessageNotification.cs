using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mn = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            int p = 2;
            var values = mn.GetInboxLİstByWriter(p);
            return View(values);
        }
    }
}
