using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }

        }

        List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel {BID=1,BName="C# Programlamaya giriş"},
                new BlogModel {BID=2,BName="Tesla firmasının araçları"},
                new BlogModel {BID=3,BName="2020 Olimpiyatları"}
            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }



        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BMID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BMName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }
        }
      
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2()
                {
                    BMID = x.BlogID,
                    BMName = x.Title
                }).ToList();
                return bm;
            }
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
