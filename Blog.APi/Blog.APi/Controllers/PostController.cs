using AutoMapper;
using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Resources;
using Blog.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace Blog.APi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    [AllowAnonymous]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly IUnitOfWork _unitOfWork;

        public PostController(
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IPropertyMappingService propertyMappingService,
            IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _propertyMappingService = propertyMappingService;
            _unitOfWork = unitOfWork;
        }

        #region Get
        /// <summary>
        /// 返回分页、过滤、搜索、排序后的数据
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPosts))]
        [HttpHead]
        public async Task<IActionResult> GetPosts([FromQuery] PostResourceParameters parameters)
        {
            //验证排序字段
            if (!_propertyMappingService.ValidMappingExistsFor<PostResource, Post>(parameters.OrderBy))
            {
                return BadRequest();
            }
            //取分好页的数据
            var posts = await _postRepository.GetAllPostsAsync(parameters);
            ////上一页的链接
            var previousLink = posts.HasPrevious ? CreatePostResourceUri(parameters, ResourceUriType.PreviousPage) : null;
            //下一页的链接
            var nextLink = posts.HasNext ? CreatePostResourceUri(parameters, ResourceUriType.NextPage) : null;
            var paginationMetadata = new
            {
                totalCount = posts.TotalItemCount, //总数
                pageSize = posts.PageSize,         //每页数量
                pageIndex = posts.PageIndex,       //当前页号
                totalPages = posts.PageCount,      //总页数
                previousLink,                      //前一页链接
                nextLink                           //后一页链接
            };
            //在相应的Header加上分页信息
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata,
                new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                }));
            //post->postResource
            var postResources = _mapper.Map<IEnumerable<PostResource>>(posts);
            //postResources
            return Ok(postResources);
        }
        /// <summary>
        /// 获得指定id的帖子
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetPost))]
        public async Task<IActionResult> GetPost(Guid id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            var postResource = _mapper.Map<PostResource>(post);
            return Ok(postResource);
        }
        #endregion


        //未分类 552740eb-e24f-415d-bf84-e3bb0242080b
        //获取当前登录的用户名
        //var userName = User.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.PreferredUserName)?.Value;

        #region Post
        [HttpPost(Name = "CreatePost")]
        public async Task<ActionResult<PostResource>> CreatePost([FromBody]PostAddResource postAddResource)
        {
            var abs = ContentProcessor.GetPostAbstract(postAddResource.Content, 400);
            var newPost = _mapper.Map<PostAddResource, Post>(postAddResource);
            newPost.ContentAbstract = abs;
            newPost.Id = Guid.NewGuid();
            if (postAddResource.CategoryIds != null&&postAddResource.CategoryIds.Length!=0)
            {
                foreach (var cid in postAddResource.CategoryIds)
                {
                    if (await _categoryRepository.CheckCategoryByIdAsync(cid))
                    {
                        newPost.PostCategories.Add(new PostCategory
                        {
                            CategoryId=cid,
                            PostId = newPost.Id
                        });
                    }
                }
            }
            newPost.LastModified = DateTime.Now;
            _postRepository.AddPost(newPost);
            if (!await _unitOfWork.SaveAsync()) throw new Exception("Save Failed!");
            var resultResource = _mapper.Map<Post, PostResource>(newPost);
            return CreatedAtRoute("GetPost", new { id = resultResource.Id},resultResource);
        }

        #endregion

        #region Delete

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            _postRepository.Delete(post);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting post {id} failed when saving");
            }
            return NoContent();
        }

        #endregion

        #region PUT
        [HttpPut("{id}", Name = "UpdatePost")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] PostUpdateResource postUpdate)
        {
            if (postUpdate == null)
            {
                return BadRequest();
            }

            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            //获取当前登录的用户名
            //var userName = User.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.PreferredUserName)?.Value;
            //newPost.Author = userName;
            post.LastModified = DateTime.Now;
            _mapper.Map(postUpdate, post);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating post {id} failed when saving");
            }

            return NoContent();
        }


        #endregion

        #region PATCH
        [HttpPatch("{id}", Name = "PartiallyUpdatePost")]
        public async Task<IActionResult> PartiallyUpdatePost(Guid id, [FromBody] JsonPatchDocument<PostUpdateResource> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            var postToPatch = _mapper.Map<PostUpdateResource>(post);
            patchDoc.ApplyTo(postToPatch);
            TryValidateModel(postToPatch);
            //把postUpdateResource转回post
            _mapper.Map(postToPatch, post);
            post.LastModified = DateTime.Now;
            var abs = ContentProcessor.GetPostAbstract(post.Content, 400);
            post.ContentAbstract = abs;
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"patching city {id} failed when saving");
            }

            return NoContent();
        }
        #endregion

        #region service
        /// <summary>
        /// 创建翻页链接
        /// </summary>
        /// <param name="parameters">PostResourceParameters</param>
        /// <param name="type">ResourceUriType</param>
        /// <returns>link</returns>
        private string CreatePostResourceUri(PostResourceParameters parameters, ResourceUriType type = ResourceUriType.CurrentPage)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(nameof(GetPosts), new
                    {
                        orderby = parameters.OrderBy,
                        pageIndex = parameters.PageIndex - 1,
                        pageSize = parameters.PageSize,
                        KeyWords = parameters.KeyWords
                    });
                case ResourceUriType.NextPage:
                    return Url.Link(nameof(GetPosts), new
                    {
                        orderby = parameters.OrderBy,
                        pageIndex = parameters.PageIndex + 1,
                        pageSize = parameters.PageSize,
                        KeyWords = parameters.KeyWords
                    });
                default:
                    return Url.Link(nameof(GetPosts), new
                    {
                        orderby = parameters.OrderBy,
                        pageIndex = parameters.PageIndex,
                        pageSize = parameters.PageSize,
                        KeyWords = parameters.KeyWords
                    });
            }
        }


        #endregion
    }
}
