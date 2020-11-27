using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Extensions;
using Blog.Infrastructure.Resources;
using Blog.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;

        public PostRepository(BlogDbContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService;
        }
        public async Task<PagedList<Post>> GetAllPostsAsync(PostResourceParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var queryExpression = _context.Posts as IQueryable<Post>;

            //根据参数过滤
            //if (!string.IsNullOrWhiteSpace(parameters.Remark))
            //{
            //    parameters.Remark = parameters.Remark.Trim();
            //    queryExpression = queryExpression.Where(x => x==parameters.Remark);
            //}
            //根据关键字搜索
            if (!string.IsNullOrWhiteSpace(parameters.KeyWords))
            {
                parameters.KeyWords = parameters.KeyWords.Trim().ToLower();
                queryExpression = queryExpression.Where(x => x.Title.ToLower().Contains(parameters.KeyWords));
            }

            var mappingDictionary = _propertyMappingService.GetPropertyMapping<PostResource, Post>();
            var count = await queryExpression.CountAsync();
            queryExpression = queryExpression.ApplySort(parameters.OrderBy, mappingDictionary);
            queryExpression = queryExpression.Skip((parameters.PageIndex - 1) * parameters.PageSize).Take(parameters.PageSize);
            queryExpression = queryExpression.Include(pc => pc.PostCategories).ThenInclude(c => c.Category);
            var items = await queryExpression.ToListAsync();
            return new PagedList<Post>(items, count, parameters.PageIndex, parameters.PageSize);

        }

        public async Task<Post> GetPostByIdAsync(Guid id)
        {
            return await _context.Posts.AsQueryable().Include(pc => pc.PostCategories).ThenInclude(c => c.Category).FirstOrDefaultAsync((x => x.Id == id));
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
        }
        //会自动检测修改
        public void Update(Post post)
        {
            // _context.Entry(employee).State = EntityState.Modified;
        }
    }
}
