namespace BlazorCMS.Grid
{
    // Interface for sorting
    public interface IContactSort
    {
        // The Contact Sort Column being sorted
        ContactSortColumns SortColumn { get; set; }

        // A value indicating if the sort is ascending or descending
        bool SortAscending { get; set; }

        // Loading indicator
        bool Loading { get; set; }

        // Paging state in PageHelper
        IPageHelper PageHelper { get; set; }
    }
}
