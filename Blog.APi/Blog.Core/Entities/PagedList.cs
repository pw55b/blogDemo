using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Entities
{
    /// <summary>
    /// 翻页源数据类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T> where T : class
    {
        private int _totalItemCount;
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount =>  (int)Math.Ceiling(TotalItemCount / (double)PageSize);
        public int TotalItemCount
        {
            get => _totalItemCount;
            set => _totalItemCount = value >= 0 ? value : 0;
        }
        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < PageCount ;
        public PagedList(IEnumerable<T> items, int totalItemCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
            AddRange(items);
        }
        //public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return new PagedList<T>(items, count, pageIndex, pageSize);
        //}
    }
}