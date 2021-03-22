namespace BlazorCMS.Grid
{
    // Will do the math and will hold the state for paging
    public class PageHelper : IPageHelper
    {
        // 10 items appear on a page.
        public int PageSize { get; set; } = 10;

        // Current page, 1-based.
        public int Page { get; set; }

        // <c>true</c> when previous page exists.
        public bool HasPrevPage => Page > 1;

        // Previous page number.
        public int PrevPage => Page <= 1 ? Page : Page - 1;

        // <c>true</c> when next page exists.
        public bool HasNextPage => Page < PageCount;

        // Next page number.
        public int NextPage => Page < PageCount ? Page + 1 : Page;

        // Total items across all pages.
        public int TotalItemCount { get; set; }

        // Items on the current page (should be less than or equal to PageSize
        public int PageItems { get; set; }

        // Current page, 0-based.
        public int DbPage => Page - 1;

        // How many records to skip to start current page.
        public int Skip => PageSize * DbPage;

        // Total number of pages.
        public int PageCount => (TotalItemCount + PageSize - 1) / PageSize;
    }
}
