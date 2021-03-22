using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorCMS.Data
{
    // Contact entity
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Last name must have a maximum of 250 characters!")]
        public string LastName { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "First name must have a maximum of 250 characters!")]
        public string FirstName { get; set; }

        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits!")]
        public string PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
