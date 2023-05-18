using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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


        public Blog BlogGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> BlogListGetById(int id) 
        {
            return _blogDal.GetListAll(x=>x.BlogID== id);
        }
      public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
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
           _blogDal.Update(blog);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TUpdate(Blog t)
        {
            
            _blogDal.Update(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public List<Blog> GetList()
        {
            throw new NotImplementedException();
        }

        public Blog TGetById(int id)
        {
           return _blogDal.GetById(id);
        }
    }
}
