using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface IPostCategoriesRepository
    {
        Task<IEnumerable<PostCategory>> GetAllCategoriesIdByPostIdAsync(Guid postId);
        Task<IEnumerable<Guid>> GetAllCategoriesIdByPostIdAsync(IEnumerable<Guid> postId);
        Task<IEnumerable<PostCategory>> GetAllPostsByCategoryIdAsync(Guid categoryId);
        void AddPostCategory(PostCategory postCategory);

        void DeletePostCategory(PostCategory postCategory);

        void UpdatePostCategory(PostCategory postCategory);

    }
}
