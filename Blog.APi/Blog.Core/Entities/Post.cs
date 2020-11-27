using Blog.Core.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Core.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentAbstract { get; set; }
        //public string Author { get; set; }
        public DateTime LastModified { get; set; }
        //public string Remark { get; set; }
        public  List<PostCategory> PostCategories { get; set; }

    }
}
