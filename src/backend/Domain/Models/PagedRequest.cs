namespace Kanafka.Admin.Domain.Models;

/// <summary>
/// Generic pagination request data model.
/// </summary>
public class PagedRequest
{
    public PagedRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    
    /// <summary>
    /// Number of the desired page.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Size of the desired page.
    /// </summary>
    public int PageSize { get; set; }
}