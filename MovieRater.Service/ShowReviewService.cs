using MovieRater.Data;
using MovieRater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class ShowReviewService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;
        public ShowReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ShowReviewCreate model)
        {
            ShowReview review = new ShowReview()
            {
                UserId = _userId,
                ReviewText = model.ReviewText,
                Score = model.Score,
                CreatedUtc = DateTimeOffset.Now,
                ShowId = model.ShowId
            };

            _context.ShowReviews.Add(review);
            return _context.SaveChanges() == 1;
        }

        public List<ShowReviewListItem> GetAllReviews()
        {
            List<ShowReview> reviews = _context.ShowReviews.ToList();
            List<ShowReviewListItem> reviewListItems = reviews.Select(r => new ShowReviewListItem()
            {
                ReviewId = r.ReviewId,
                UserId = r.UserId,
                Score = r.Score,
                ReviewText = r.ReviewText,
                CreatedUtc = r.CreatedUtc,
                ModifiedUtc = r.ModifiedUtc,
                ShowId = r.ShowId,
                Show = new ShowDisplayItem
                {
                    Title = r.Show.Title,
                    Genre = r.Show.Genre
                }
            }).ToList();

            return reviewListItems;
        }

        public ReviewDetail GetReviewById(int Id)
        {
            Review reviewToGet = _context.Reviews.Single(r => r.ReviewId == Id);
            ReviewDetail review = new ReviewDetail
            {
                ReviewId = reviewToGet.ReviewId,
                UserId = reviewToGet.UserId,
                Score = reviewToGet.Score,
                ReviewText = reviewToGet.ReviewText,
                CreatedUtc = reviewToGet.CreatedUtc,
                ModifiedUtc = reviewToGet.ModifiedUtc
            };

            return review;
        }
    }
}

