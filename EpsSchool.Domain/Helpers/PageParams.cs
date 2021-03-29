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

        public int MaxPageSize { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int? Registration { get; private set; }
        public string Name { get; private set; }
        public int? Status { get; private set; }
    }
}