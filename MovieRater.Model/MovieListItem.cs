using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class MovieListItem
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }
        [Display(Name="Added")]
        public DateTimeOffset AddedMovie { get; set; }
        public string Review { get; set; }
    }
}
