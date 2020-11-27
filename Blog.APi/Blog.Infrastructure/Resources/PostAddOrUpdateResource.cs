using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.Entities;

namespace Blog.Infrastructure.Resources
{
   public class PostAddOrUpdateResource
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentAbstract { get; set; }
        public DateTime LastModified { get; set; }
        public Guid[] CategoryIds { get; set; }
    }
}
