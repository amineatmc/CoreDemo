using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm= new MessageManager(new EfMessageRepository());
        Context context = new Context();
        public IActionResult InBox()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxLİstByWriter(writerID);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetListWithSendMessageByWriter(writerID);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
           
            var value = mm.TGetById(id);
            return View(value);
        }

        [HttpGet]

        public async Task< IActionResult> SendMessage()
        {
            //KUllanıcıları DropDown'a Çektiğimiz Alan            
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
        public IActionResult SendMessage(Message2 p)
        {
            int writerID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            p.SenderID = writerID;
            p.MessageStatus = true;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);

            return RedirectToAction("Inbox");
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
