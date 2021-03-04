using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "Review score must be between 1 and 10")]
        public double Score { get; set; }

        public string ReviewText { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }


    }
}
