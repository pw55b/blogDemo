using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Entities
{
   public class Category:Entity
    {
        public string Name { get; set; }
        public string  Note { get; set; }
        public List<PostCategory> PostCategories { get; set; }
    }
}
