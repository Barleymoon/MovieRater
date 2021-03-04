using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class ShowReviewCreate
    {
        [Required]
        [Range(0, 10, ErrorMessage = "Review score should be between 1 and 10")]
        public double Score { get; set; }

        public string ReviewText { get; set; }

        public int ShowId { get; set; }
    }
}
