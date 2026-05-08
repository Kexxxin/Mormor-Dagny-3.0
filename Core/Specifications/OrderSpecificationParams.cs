namespace Core.Specifications;

public class OrderSpecificationParams
{

    private const int MAX_PAGE_SIZE = 50;
    private int _pageSize = 30;
    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
    }

    public string? OrderNumber { get; set; }
    public DateTime? Date { get; set; }

}
