using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context context = new Context();

        public IActionResult InBox()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxLİstByWriter(writerID);
            ViewBag.v = values.Count;
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetListWithSendMessageByWriter(writerID);
            ViewBag.v = values.Count;
            return View(values);
        }

        [HttpGet]
        public async Task< IActionResult >ComposeMessage()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxLİstByWriter(writerID);
            ViewBag.v = values.Count;
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Email.ToString(),
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            //Burası Yukarıde Çektiğimiz Verileri Front-End Tarafına Taşıyoruz.
            ViewBag.RecieverUser = recieverUsers;
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 p)
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxLİstByWriter(writerID);
            ViewBag.v = values.Count;
            p.SenderID = writerID;
            p.ReceiverID = 2;
            p.MessageStatus = true;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("SendBox");
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}
