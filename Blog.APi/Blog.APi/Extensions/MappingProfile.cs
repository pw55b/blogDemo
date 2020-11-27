using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Entities;
using Blog.Infrastructure.Resources;

namespace Blog.APi.Extensions
{
    //配置AutoMapper映射关系
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostResource>().ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories.Select(x=>new Category
            {
                Id=x.Category.Id,
                Name=x.Category.Name,
                Note = x.Category.Note
            })));

            CreateMap<PostResource, Post>();
            CreateMap<Post, PostAddResource>();
            CreateMap<PostAddResource, Post>();
            CreateMap<Post, PostUpdateResource>();
            CreateMap<PostUpdateResource, Post>();
            CreateMap<PostImage, PostImageResource>();
            CreateMap<PostImageResource, PostImage>();
            //category
            CreateMap<CategoryAddResource,Category>();
            CreateMap<Category,CategoryAddResource>();
            CreateMap<CategoryUpdateResource, Category>();
            CreateMap<Category, CategoryUpdateResource>();

        }
    }
}
