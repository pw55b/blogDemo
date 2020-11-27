using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Entities
{
    public class PostImage : Entity
    {
        public string FileName { get; set; }
    }
}
