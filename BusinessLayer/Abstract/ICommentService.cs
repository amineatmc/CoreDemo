using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);
        //void Update(Comment comment);
        //void Delete(Comment comment);
        List<Comment> GetList(int id);
        //Comment CommentGetById(int id);
        //List<Comment> GetCommentListWithCategory();
    }
}
