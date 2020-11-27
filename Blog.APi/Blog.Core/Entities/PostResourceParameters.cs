namespace Blog.Core.Entities
{
    public class PostResourceParameters : QueryParameters
    {
        public string KeyWords { get; set; }
        //public string Remark { get; set; }
        public override string OrderBy { get; set; } = "LastModified";
    }
}
