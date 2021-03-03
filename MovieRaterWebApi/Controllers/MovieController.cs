using Microsoft.AspNet.Identity;
using MovieRater.Model;
using MovieRater.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRaterWebApi.Controllers
{
    [Authorize]
    public class MovieController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            MovieService movieService = CreateMovieService();
            var movies = movieService.GetMovies();
            return Ok(movies);
        }
        
        [HttpPost]
        public IHttpActionResult PostMovie(MovieCreate movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var service = CreateMovieService();

            if (!service.CreateMovie(movie))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var movieService = new MovieService(userId);
            return movieService;
        }
    }
}
