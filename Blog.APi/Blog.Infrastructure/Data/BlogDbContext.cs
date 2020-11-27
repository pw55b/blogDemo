using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostImage> PostImages { get; set; }

        // 对实体的限制
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Category>().Property(x => x.Note).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Post>().Property(x => x.ContentAbstract).HasMaxLength(420);
            modelBuilder.Entity<Post>().Property(x => x.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Post>().Property(x => x.Content).IsRequired();
            modelBuilder.Entity<Post>().HasKey(b => b.Id);
            //中间表的主键
            modelBuilder.Entity<PostCategory>().HasKey(t => new
            {
                t.PostId,
                t.CategoryId
            });
            //一对多
            modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Post)
                .WithMany(p => p.PostCategories)
                .HasForeignKey(pc => pc.PostId);

            modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(p => p.PostCategories)
                .HasForeignKey(pc => pc.CategoryId);
            //种子数据
            modelBuilder.Entity<Post>().HasData(
                 new Post
                 {
                     Id = Guid.Parse("B2702CEA-C9FC-4BBD-A755-53EA629C5C84"),
                     Title = "Post Title 1",
                     Content = "Post Content 1",
                     LastModified = DateTime.Now
                 },
                 new Post
                 {
                     Id = Guid.Parse("0E419CAA-22F7-41AC-8EE6-44E6E3BA27C8"),
                     Title = "Post Title 2",
                     Content = "Post Content 2",
                     LastModified = DateTime.Now
                 },
                 new Post
                 {
                     Id = Guid.Parse("0A7FE9E9-F8CB-4237-A1AC-948E0CCF76F2"),
                     Title = "Post Title 3",
                     Content = "Post Content 3",
                     LastModified = DateTime.Now
                 },
                 new Post
                 {
                     Id = Guid.Parse("0AA35BD0-C08F-485C-BDD8-62FC9CBA9837"),
                     Title = "Post Title 4",
                     Content = "Post Content 4",
                     LastModified = DateTime.Now
                 },
                 new Post
                 {
                     Id = Guid.Parse("D4B22650-8527-4325-B6B3-15828255DC47"),
                     Title = "Post Title 5",
                     Content = "Post Content 5",
                     LastModified = DateTime.Now
                 },
                 new Post
                 {
                     Id = Guid.Parse("0EE57ED6-5F8B-49F7-933C-06D09E71AD1E"),
                     Title = "Post Title 6",
                     Content = "Post Content 6",
                     LastModified = DateTime.Now
                 },
                 new Post
                 {
                     Id = Guid.Parse("13FF2270-7776-4442-83BF-551D8BC72FF8"),
                     Title = "Post Title 7",
                     Content = "Post Content 7",
                     LastModified = DateTime.Now
                 },
                 new Post
                 {
                     Id = Guid.Parse("7F886DC4-48F9-479C-B10C-EDB4451BFCBB"),
                     Title = "Post Title 8",
                     Content = "Post Content 8",
                     LastModified = DateTime.Now
                 }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("24272CF6-79D3-4550-B5B9-A71297A04A75"),
                    Name = "C#",
                    Note = "一种编程语言"
                },
                new Category 
                {
                Id = Guid.Parse("023CC1B2-1EF7-40D7-B07C-0164ED0BB44A"),
                Name = "asp.net core",
                Note = "是一个跨平台的高性能开源框架"
                },
                new Category
                {
                    Id = Guid.Parse("7F65E5A6-00AB-4CF6-9C17-996905936406"),
                    Name = "EF",
                    Note = "一种关系映射器"
                }
            );
            modelBuilder.Entity<PostCategory>().HasData(
                new PostCategory
                {
                    CategoryId = Guid.Parse("7F65E5A6-00AB-4CF6-9C17-996905936406"),
                    PostId = Guid.Parse("0EE57ED6-5F8B-49F7-933C-06D09E71AD1E")
                },
                new PostCategory
                {
                    CategoryId = Guid.Parse("7F65E5A6-00AB-4CF6-9C17-996905936406"),
                    PostId = Guid.Parse("D4B22650-8527-4325-B6B3-15828255DC47")
                },
                new PostCategory
                {
                    CategoryId = Guid.Parse("023CC1B2-1EF7-40D7-B07C-0164ED0BB44A"),
                    PostId = Guid.Parse("0EE57ED6-5F8B-49F7-933C-06D09E71AD1E")
                },
                new PostCategory
                {
                    CategoryId = Guid.Parse("023CC1B2-1EF7-40D7-B07C-0164ED0BB44A"),
                    PostId = Guid.Parse("D4B22650-8527-4325-B6B3-15828255DC47")
                },
                new PostCategory
                {
                    CategoryId = Guid.Parse("24272CF6-79D3-4550-B5B9-A71297A04A75"),
                    PostId = Guid.Parse("7F886DC4-48F9-479C-B10C-EDB4451BFCBB")
                },
                new PostCategory
                {
                    CategoryId = Guid.Parse("24272CF6-79D3-4550-B5B9-A71297A04A75"),
                    PostId = Guid.Parse("13FF2270-7776-4442-83BF-551D8BC72FF8")
                }
                );
        }
    }
}
