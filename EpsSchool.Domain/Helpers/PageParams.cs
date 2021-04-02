namespace EpsSchool.Domain.Helpers
{
    public class PageParams
    {
        public PageParams(int pageNumber, string name)
        {
            PageNumber = pageNumber;
            Name = name;
            MaxPageSize = 50;
            PageNumber = 1;
            PageSize = (PageSize > MaxPageSize) ? MaxPageSize : PageSize;
            Registration = null;
            Name = string.Empty;
            Status = null;
        }

        public int MaxPageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? Registration { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
    }
}