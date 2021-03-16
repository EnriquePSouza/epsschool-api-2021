using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Api.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public static async Task<PageList<T>> CreateAsync(
            IQueryable<T> source, int pageNumber, int pageSize)
        {
            // Conta a quantidade total de itens.
            var count = await source.CountAsync();
            // O -1 é pq começa no zero e depois sempre diminui 1 para saber quantos itens pular na hora de paginar.
            var items = await source.Skip((pageNumber-1) * pageSize) 
                                     .Take(pageSize)
                                     .ToListAsync();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}