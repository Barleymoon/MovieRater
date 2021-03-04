using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class ShowListItem
    {
        public int ShowId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        [Display(Name= "Created")]
        public DateTimeOffset AddedShow { get; set; }
    }
}
