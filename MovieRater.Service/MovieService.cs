using MovieRater.Data;
using MovieRater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Genre = model.Genre,
                    Actors = model.Actors
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Movies
                        .Where(m => m.OwnerId == _userId)
                        .Select(
                            m =>
                                new MovieListItem
                                {
                                    MovieId = m.MovieId,
                                    Title = m.Title,
                                    Description = m.Description,
                                    Genre = m.Genre,
                                    AddedMovie = m.AddedMovie,
                                    //Eric's Changes
                                    Reviews = m.Reviews.Select(r => new ReviewDisplayItem()
                                    {
                                        ReviewId = r.ReviewId,                                        
                                        Score = r.Score,
                                        ReviewText = r.ReviewText,                                        
                                    }).ToList()
                                }
                        );
                return query.ToArray();
            }
        }


        public MovieDetail GetMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(m => m.MovieId == id && m.OwnerId == _userId);
                return
                    new MovieDetail
                    {
                        MovieId = entity.MovieId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Rating = entity.Rating,
                        Reviews = entity.Reviews,
                        AddedMovie = entity.AddedMovie
                    };
            }
        }
         public MovieDetail GetMovieByTitle(string title)
         {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .SingleOrDefault(m => m.Title == title);
                return
                    new MovieDetail
                    {
                        MovieId = entity.MovieId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Genre = entity.Genre,
                        AddedMovie = entity.AddedMovie
                    };
            }
         }

        /*public IEnumerable<MovieListItem> GetMovieByTitle(int movieId, string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                       .Movies
                       .Where(m => m.Title == title && m.MovieId == movieId)
                       .Select(
                            m =>
                               new MovieListItem()
                               {
                                   Title = m.Title,
                                   MovieId = m.MovieId,
                                   Description = m.Description,
                                   Genre = m.Genre,
                                   AddedMovie = m.AddedMovie,
                               }
                        );
                return query.ToArray();
            }
        }*/

    }
}
