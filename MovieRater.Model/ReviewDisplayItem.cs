using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class ReviewDisplayItem
    {
        public int ReviewId { get; set; }
        public double Score { get; set; }
        public string ReviewText { get; set; }
    }
}
