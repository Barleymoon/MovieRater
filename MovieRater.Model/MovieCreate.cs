using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class MovieCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Please keep Title under 50 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Actors { get; set; }
        public string Genre { get; set; }
    }
}
