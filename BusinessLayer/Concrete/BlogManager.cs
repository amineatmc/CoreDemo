using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogServices
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog BlogGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> BlogListGetById(int id) 
        {
            return _blogDal.GetListAll(x=>x.BlogID== id);
        }
        public void Delete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }
        public List<Blog> GetLastTreeBlog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

		public List<Blog> GetBlogListWriter(int id)
		{
            return _blogDal.GetListAll(x => x.WriterID == id);

		}

		public void Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
