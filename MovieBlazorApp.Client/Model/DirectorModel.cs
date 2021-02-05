using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazorApp.Client.Model
{
    public class DirectorModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(maximumLength:30, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 30 characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 30 characters long")]
        public string LastName { get; set; }
    }
}
