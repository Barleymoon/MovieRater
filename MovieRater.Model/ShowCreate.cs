using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class ShowCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Title must be more than one character.")]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Description must be more than 3 characters.")]
        public string Description { get; set; }
        
    }
}
