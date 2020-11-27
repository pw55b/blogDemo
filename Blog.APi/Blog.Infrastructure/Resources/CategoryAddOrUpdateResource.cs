using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Resources
{
   public class CategoryAddOrUpdateResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }

   public class CategoryAddResource : CategoryAddOrUpdateResource
   {

   }

   public class CategoryUpdateResource : CategoryAddOrUpdateResource
   {

   }
}
