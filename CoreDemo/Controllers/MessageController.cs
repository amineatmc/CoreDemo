﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessageManager mm= new MessageManager(new EfMessageRepository());

        public IActionResult InBox()
        {
            int id = 2;
            var values = mm.GetInboxLİstByWriter(id);
            return View(values);
        }


        public IActionResult MessageDetails(int id)
        {
           
            var value = mm.TGetById(id);
            return View(value);
        }
    }
}