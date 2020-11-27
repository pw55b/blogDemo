using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.APi.Controllers
{
    [Route("api/Postimages")]
    public class PostImageController:Controller
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostImageController(
            IPostImageRepository postImageRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _postImageRepository = postImageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        #region post

        [HttpPost]
        [AllowAnonymous]
        //上传单个文件类型是IFormFile 多个是IFormFilexxxxx什么的
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file==null)
            {
                return BadRequest("File is null");
            }

            if (file.Length==0)
            {
                return BadRequest("File is empty");
            }

            if (file.Length>10*1024*1024)
            {
                return BadRequest("File size cannot exceed 10M");
            }

            var acceptTypes = new[] {".jpg", ".jpeg", ".png"};
            if (acceptTypes.All(x=>x!=Path.GetExtension(file.FileName).ToLower()))
            {
                return BadRequest("File type not valid,only jpg and png are acceptable");
            }

            if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
            {
                _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            var uploadsFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileNmae = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileNmae);
            using (var stream=new FileStream(filePath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var postImage = new PostImage
            {
                FileName = fileNmae
            };
            _postImageRepository.Add(postImage);
            await _unitOfWork.SaveAsync();
            var result = _mapper.Map<PostImage, PostImageResource>(postImage);
            return Ok(result);
        }
        #endregion
    }
}
