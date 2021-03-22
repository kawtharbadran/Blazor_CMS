namespace BlazorCMS.Grid
{
    // Interface for pager
    public interface IPageHelper
    {
        // Current page, 0-based.
        int DbPage { get; }

        // Current page, 1-based.
        int Page { get; set; }

        // Previous page, 1-based.
        int PrevPage { get; }

        // Next page, 1-based.
        int NextPage { get; }

        // true when a previous page exists.
        bool HasPrevPage { get; }

        // true when a next page exists.
        bool HasNextPage { get; }

        // Total page count.
        int PageCount { get; }

        // Items on current page.
        int PageItems { get; set; }

        // Items per page.
        int PageSize { get; set; }

        // How many items to skip.
        int Skip { get; }

        // Total items based on filter.
        int TotalItemCount { get; set; }
    }
}
