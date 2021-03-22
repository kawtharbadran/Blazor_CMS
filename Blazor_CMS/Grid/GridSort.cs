namespace BlazorCMS.Grid
{
    public class GridSort : IContactSort
    {
        // Keep state of pager
        public IPageHelper PageHelper { get; set; }

        // To avoid multiple concurrent requests
        public bool Loading { get; set; }

        // Constructor
        public GridSort(IPageHelper pageHelper)
        {
            PageHelper = pageHelper;
        }

        // Column to sort by
        public ContactSortColumns SortColumn { get; set; }
            = ContactSortColumns.LastName;

        // True when sorting ascending, otherwise sort descending
        public bool SortAscending { get; set; } = true;
    }
}
