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

        [Required]
        public int ShowId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }

        public List<string> Actors { get; set; }



    }
}
