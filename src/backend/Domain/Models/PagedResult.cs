namespace Kanafka.Admin.Domain.Models;

public class PagedResult<TResult>
{
    public List<TResult> Results { get; set; } = new();

    public int CurrentPage { get; set; }

    public int PageCount { get; set; }

    public int PageSize { get; set; }

    public int RowCount { get; set; }

    public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;

    public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
}