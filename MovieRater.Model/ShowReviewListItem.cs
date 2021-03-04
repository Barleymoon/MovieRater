using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class ShowReviewListItem
    {
        public int ReviewId { get; set; }
        public Guid UserId { get; set; }
        public double Score { get; set; }
        public string ReviewText { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }



        public int ShowId { get; set; }
        public ShowDisplayItem Show { get; set; }
    }
}
