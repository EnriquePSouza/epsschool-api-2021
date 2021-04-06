using System;

namespace EpsSchool.Domain.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string Enrollment { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = null;
    }
}