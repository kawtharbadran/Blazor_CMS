using BlazorCMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorCMS.Grid
{
    public class GridQueryAdapter
    {
        // Holds state of the grid
        private readonly IContactSort controls;

        // Expressions for sorting
        private readonly Dictionary<ContactSortColumns, Expression<Func<Contact, string>>> sortOptions
            = new Dictionary<ContactSortColumns, Expression<Func<Contact, string>>>
            {
                { ContactSortColumns.LastName, c => c.LastName },
                { ContactSortColumns.FirstName, c => c.FirstName }
            };

        // Constructor to create a new instance of the Grid Query Adapter
        public GridQueryAdapter(IContactSort controls)
        {
            this.controls = controls;
        }

        // Uses the contacts query to return a count and a page
        // parameter contacts is the IQueryable<Contact> to work from
        // returns the resulting ICollection<Contact>
        public async Task<ICollection<Contact>> FetchAsync(IQueryable<Contact> contacts)
        {
            contacts = Query(contacts);
            await CountAsync(contacts);
            List<Contact> contactsList = await FetchPageQuery(contacts).ToListAsync();
            controls.PageHelper.PageItems = contactsList.Count;
            return contactsList;
        }

        // Get total sorted contacts
        // parameter contacts is the IQueryable<Contact> to use
        // returns>Asynchronous Task 
        public async Task CountAsync(IQueryable<Contact> contacts)
        {
            controls.PageHelper.TotalItemCount = await contacts.CountAsync();
        }

        // Build the query to bring back a single grid page of contacts
        // parameter contacts is the IQueryable<Contact> to modify
        // returns The new IQueryable<Contact> for a page
        public IQueryable<Contact> FetchPageQuery(IQueryable<Contact> contacts)
        {
            return contacts
                .Skip(controls.PageHelper.Skip)
                .Take(controls.PageHelper.PageSize)
                .AsNoTracking();
        }

        // Builds the contacts query
        // parameter contacts is the IQueryable<Contact> to start with
        // The resulting IQueryable<Contact> after sorting it
        private IQueryable<Contact> Query(IQueryable<Contact> contacts)
        {
            var stringBuilder = new System.Text.StringBuilder();

            // apply the expression for sorting
            var sortOption = sortOptions[controls.SortColumn];

            // This string just for debugging purposes
            stringBuilder.Append($"Sort: '{controls.SortColumn}' ");

            // Add sorting direction to the debug string and write the string to console
            string sortOrder = controls.SortAscending ? "ASC" : "DESC";
            stringBuilder.Append(sortOrder);
            Debug.WriteLine(stringBuilder.ToString());

            // return the sorted contacts based on the sorting option selected
            return controls.SortAscending ? contacts.OrderBy(sortOption)
                : contacts.OrderByDescending(sortOption);
        }
    }
}
