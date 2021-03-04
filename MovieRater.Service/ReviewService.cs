using MovieRater.Data;
using MovieRater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;
        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            Review review = new Review()
            {
                UserId = _userId,
                ReviewText = model.ReviewText,
                Score = model.Score,
                CreatedUtc = DateTimeOffset.Now,
                MovieId = model.MovieId
            };

            _context.Reviews.Add(review);
            return _context.SaveChanges() == 1;
        }

        public List<ReviewListItem> GetAllReviews()
        {
            List<Review> reviews = _context.Reviews.ToList();
            List<ReviewListItem> reviewListItems = reviews.Select(r => new ReviewListItem()
            {
                ReviewId = r.ReviewId,
                UserId = r.UserId,
                Score = r.Score,
                ReviewText = r.ReviewText,
                CreatedUtc = r.CreatedUtc,
                ModifiedUtc = r.ModifiedUtc,
                MovieId = r.MovieId,
                Movie = new MovieDisplayItem
                {
                    Title = r.Movie.Title,
                    Genre = r.Movie.Genre
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
