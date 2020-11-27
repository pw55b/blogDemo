﻿// <auto-generated />
using System;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20201125141754_addMiddletable")]
    partial class addMiddletable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("24272cf6-79d3-4550-b5b9-a71297a04a75"),
                            Name = "C#",
                            Note = "一种编程语言"
                        },
                        new
                        {
                            Id = new Guid("023cc1b2-1ef7-40d7-b07c-0164ed0bb44a"),
                            Name = "asp.net core",
                            Note = "是一个跨平台的高性能开源框架"
                        },
                        new
                        {
                            Id = new Guid("7f65e5a6-00ab-4cf6-9c17-996905936406"),
                            Name = "EF",
                            Note = "一种关系映射器"
                        });
                });

            modelBuilder.Entity("Blog.Core.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentAbstract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"),
                            Content = "Post Content 1",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 119, DateTimeKind.Local).AddTicks(5602),
                            Title = "Post Title 1"
                        },
                        new
                        {
                            Id = new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"),
                            Content = "Post Content 2",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6421),
                            Title = "Post Title 2"
                        },
                        new
                        {
                            Id = new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"),
                            Content = "Post Content 3",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6554),
                            Title = "Post Title 3"
                        },
                        new
                        {
                            Id = new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"),
                            Content = "Post Content 4",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6566),
                            Title = "Post Title 4"
                        },
                        new
                        {
                            Id = new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                            Content = "Post Content 5",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6577),
                            Title = "Post Title 5"
                        },
                        new
                        {
                            Id = new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                            Content = "Post Content 6",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6588),
                            Title = "Post Title 6"
                        },
                        new
                        {
                            Id = new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                            Content = "Post Content 7",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6600),
                            Title = "Post Title 7"
                        },
                        new
                        {
                            Id = new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                            Content = "Post Content 8",
                            LastModified = new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6611),
                            Title = "Post Title 8"
                        });
                });

            modelBuilder.Entity("Blog.Core.Entities.PostCategory", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategory");

                    b.HasData(
                        new
                        {
                            PostId = new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                            CategoryId = new Guid("7f65e5a6-00ab-4cf6-9c17-996905936406")
                        },
                        new
                        {
                            PostId = new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                            CategoryId = new Guid("7f65e5a6-00ab-4cf6-9c17-996905936406")
                        },
                        new
                        {
                            PostId = new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                            CategoryId = new Guid("023cc1b2-1ef7-40d7-b07c-0164ed0bb44a")
                        },
                        new
                        {
                            PostId = new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                            CategoryId = new Guid("023cc1b2-1ef7-40d7-b07c-0164ed0bb44a")
                        },
                        new
                        {
                            PostId = new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                            CategoryId = new Guid("24272cf6-79d3-4550-b5b9-a71297a04a75")
                        },
                        new
                        {
                            PostId = new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                            CategoryId = new Guid("24272cf6-79d3-4550-b5b9-a71297a04a75")
                        });
                });

            modelBuilder.Entity("Blog.Core.Entities.PostImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostImages");
                });

            modelBuilder.Entity("Blog.Core.Entities.PostCategory", b =>
                {
                    b.HasOne("Blog.Core.Entities.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Core.Entities.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
