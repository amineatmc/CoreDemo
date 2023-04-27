using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogServices
    {
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
        List<Blog> GetAll();
        Blog BlogGetById(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog>GetBlogListWriter(int id);
        
    }

}
