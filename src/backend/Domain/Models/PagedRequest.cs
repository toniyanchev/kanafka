namespace Kanafka.Admin.Domain.Models;

public class PagedRequest
{
    public PagedRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}