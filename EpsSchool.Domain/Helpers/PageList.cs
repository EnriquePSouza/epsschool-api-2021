using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Domain.Helpers
{
    public class PageList<T> : List<T>
    {
        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PageList<T>> CreateAsync(
            IQueryable<T> source, int pageNumber, int pageSize)
        {
            // Counts the total quantity of items.
            var count = await source.CountAsync();
            // The -1 is because it starts at zero and then always decreases 1 to know how many items to skip when paging.
            var items = await source.Skip((pageNumber-1) * pageSize) 
                                     .Take(pageSize)
                                     .ToListAsync();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}