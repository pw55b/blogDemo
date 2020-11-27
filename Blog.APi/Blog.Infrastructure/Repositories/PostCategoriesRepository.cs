using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Extensions;
using Blog.Infrastructure.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Blog.Infrastructure.Repositories
{
    public class PostCategoriesRepository:IPostCategoriesRepository
    {
        private readonly BlogDbContext _context;

        public PostCategoriesRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostCategory>> GetAllCategoriesIdByPostIdAsync(Guid postId )
        {
            return await _context.PostCategories.Where(x=>x.PostId==postId).ToListAsync();
        }
        public async Task<IEnumerable<Guid>> GetAllCategoriesIdByPostIdAsync(IEnumerable<Guid> postIds)
        {
            var categoryIdList = from pc in _context.PostCategories.AsQueryable()
                join id in postIds.AsQueryable() on pc.PostId equals id
                select pc.CategoryId;
            return await categoryIdList.ToListAsync();
        }

        public async Task<IEnumerable<PostCategory>> GetAllPostsByCategoryIdAsync(Guid categoryId)
        {
            return await _context.PostCategories.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
        //public async Task<PostCategory> GetPostByIdAsync(Guid id)
        //{
        //    return await _context.PostCategories.FindAsync(id);
        //}

        public void AddPostCategory(PostCategory postCategory)
        {
            _context.PostCategories.Add(postCategory);
        }

        public void DeletePostCategory(PostCategory postCategory)
        {
            _context.PostCategories.Remove(postCategory);
        }
        //会自动检测修改
        public void UpdatePostCategory(PostCategory postCategory)
        {
            // _context.Entry(employee).State = EntityState.Modified;
        }
    }
}
