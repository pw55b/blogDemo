using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Infrastructure.Resources
{
   public class PostImageResource
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "文件名是必填的")]
        [Display(Name = "文件名")]
        [StringLength(100, ErrorMessage = "{0} 最小长度 {2}最大长度 {1}.", MinimumLength = 6)]
        public string FileName { get; set; }
        public string Location => $"/uploads/{FileName}";
    }
}
