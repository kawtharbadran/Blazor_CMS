using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCMS.Data
{
    // Service to communicate success status between pages.
    public class EditSuccess
    {
        // <c>true when the last edit operation was successful
        public bool Success { get; set; }
    }
}
