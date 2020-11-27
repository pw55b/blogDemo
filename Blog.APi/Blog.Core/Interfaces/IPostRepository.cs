using System;
using Blog.Core.Entities;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<PagedList<Post>> GetAllPostsAsync(PostResourceParameters postParameters);
        Task<Post> GetPostByIdAsync(Guid id);
        void AddPost(Post post);
        void Delete(Post post);
        void Update(Post post);
    }
}
