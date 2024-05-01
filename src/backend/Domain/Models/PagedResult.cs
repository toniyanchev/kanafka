namespace Kanafka.Admin.Domain.Models;

/// <summary>
/// Generic pagination response data model.
/// </summary>
/// <typeparam name="TResult">The type of items to be presented on the paginated list.</typeparam>
public class PagedResult<TResult>
{
    /// <summary>
    /// List of paginated items of type TResult
    /// </summary>
    public List<TResult> Results { get; set; } = new();

    /// <summary>
    /// The current page.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// The number of available pages.
    /// </summary>
    public int PageCount { get; set; }

    /// <summary>
    /// The page size
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// The total amount of items
    /// </summary>
    public int RowCount { get; set; }
}