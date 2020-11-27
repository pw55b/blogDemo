using System;
using System.Collections.Generic;
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blog.Infrastructure.Resources
{
    public class PostResource
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentAbstract { get; set; }
        public DateTime LastModified { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}
