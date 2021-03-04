using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Title must be more than one character.")]

        public string Title { get; set; }
        
        public Guid OwnerId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Description must be more than 3 characters.")]
        public string Description { get; set; }

        public string Rating { get; set; }

        public DateTimeOffset AddedShow { get; set; }

        public string Genre { get; set; }

        public virtual List<string> Reviews { get; set; }

        public List<string> Actors { get; set; }


        public string Review { get; set; }




    }
}
