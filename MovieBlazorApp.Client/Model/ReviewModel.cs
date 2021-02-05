using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazorApp.Client.Model
{
    public class ReviewModel
    {
        [Required(ErrorMessage = "Comment is required")]
        [MaxLength(length:255, ErrorMessage = "Max length of the comment is 255 characters")]
        public string Comment { get; set; }
        public int Rate { get; set; }
        public int MovieId { get; set; }
    }
}
