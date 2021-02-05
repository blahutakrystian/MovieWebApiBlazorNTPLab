using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazorApp.Client.Model
{
    public class MovieModel
    {
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Genre { get; set; }

        [Required(ErrorMessage = "Release year is required")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public int ReleaseYear { get; set; }
        public int DirectorId { get; set; }
    }
}
