using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [Required]
        [MinLength(1, ErrorMessage = "Title must be more than one character.")]
        [MaxLength(50, ErrorMessage = "Too many characters for a Title.")]
        public string Title { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Description must be more than 3 characters.")]
        [MaxLength(1000, ErrorMessage="Please kepp the description under 1000 characters.")]
        public string Description { get; set; }
        
        public DateTimeOffset AddedMovie { get; set; }
        public string Genre { get; set; }
        
        public List<string> Actors { get; set; }

        public virtual List<Review> Reviews { get; set; }
        
        public string Review { get; set; }
    }
}
