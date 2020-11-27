using System;
using System.Collections.Generic;
using System.Text;

using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;

namespace Blog.Api.Infrastructure.Repositories
{
    public  class PostImageRepository:IPostImageRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public PostImageRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public void Add(PostImage postImage)
        {
            _blogDbContext.PostImages.Add(postImage);
        }
    }
}
