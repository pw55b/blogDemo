using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> CheckCategoryByIdAsync(Guid id);
        Task<IEnumerable<Category>> GetCategories();
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}
