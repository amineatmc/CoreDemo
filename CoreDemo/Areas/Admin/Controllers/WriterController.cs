﻿using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList() 
        {
            var jsonWriters=JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findwriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters= JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult DeleteWriter(int id)
        {
            var findwriter = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(findwriter);
            return Json(findwriter);
        }

        [HttpPost]
        public IActionResult UpdateWriter(WriterClass w)
        {
            var findwriter = writers.FirstOrDefault(x => x.Id == w.Id);
            findwriter.Name = w.Name;
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);

        }


        public static List<WriterClass> writers = new List<WriterClass>()
        {
                new WriterClass()
                {
                    Id = 1,
                    Name="Ayşe"
                },
                new WriterClass()
                {
                    Id = 2,
                    Name="Mehmet"
                },
                new WriterClass()
                {
                    Id = 3,
                    Name="Fatma"
                },
        };
    }
}
