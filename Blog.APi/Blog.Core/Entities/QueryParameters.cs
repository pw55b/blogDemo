using Blog.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Blog.Core.Entities
{
    //常见参数类
    public abstract class QueryParameters
    {
        private const int DefaultPageSize = 30;
        private const int MaxPageSize = 100;
        private int _pageIndex = 1;
        private int _pageSize = DefaultPageSize;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value >= 1 ? value : 1;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public abstract string OrderBy { get; set; }
        public string Fields { get; set; }
    }
}