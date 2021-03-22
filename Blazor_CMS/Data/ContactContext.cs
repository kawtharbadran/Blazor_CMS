using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlazorCMS.Data
{
    public class ContactContext : DbContext
    {

        private readonly Guid _id;

        //public static readonly string RowVersion = nameof(RowVersion);

        public static readonly string ContactsDb = nameof(ContactsDb).ToLower();

        // List of the contacts from database
        public DbSet<Contact> Contacts { get; set; }

        // Inject options in constructor, generate PK
        // parameter "options" is the DbContextOptions<ContactContext> for our Contact Context
        public ContactContext(DbContextOptions<ContactContext> options)
             : base(options)
        {
            // generate sequential GUIDs to reduce bad splits/fragmentation in memory when inserting contacts
            var sequentialGuidGenerator = new SequentialGuidValueGenerator();
            _id = sequentialGuidGenerator.Next(null);
            Debug.WriteLine($"{_id} context created.");
        }

        // Ensure the context is disposed when the component is disposed
        public override void Dispose()
        {
            Debug.WriteLine($"{_id} context disposed.");
            base.Dispose();
        }

        // Release allocated resources and perform general cleanup for garbage collector
        public override ValueTask DisposeAsync()
        {
            Debug.WriteLine($"{_id} context disposed async.");
            return base.DisposeAsync();
        }
    }
}
