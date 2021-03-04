using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        [Display(Name="Added")]
        public DateTimeOffset AddedMovie { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedMovie { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
