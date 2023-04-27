using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<CommentUser>
            {
                new CommentUser
                {
                    ID= 1,
                    UserName="murat"
                },
                 new CommentUser
                {
                    ID= 2,
                    UserName="mesut"
                },
                  new CommentUser
                {
                    ID= 3,
                    UserName="merve"
                }
            };
            return View(commentValues);
        }
    }
}
