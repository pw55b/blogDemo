using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Entities
{
   public class PostList:Entity
    {
        public string Title { get; set; }
        public string ContentAbstract { get; set; }
        //public string Author { get; set; }
        public DateTime LastModified { get; set; }
        //public string Remark { get; set; }
        public List<PostCategory> PostCategories { get; set; }
    }
}
