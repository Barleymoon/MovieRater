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
    public class ReviewController : ApiController
    {
        [Authorize]

        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            ReviewService service = new ReviewService(userId);
            return service;
        }

        [HttpPost]
        public IHttpActionResult PostReview(ReviewCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReviewService service = CreateReviewService();
            if (!service.CreateReview(model))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllReviews()
        {
            ReviewService service = CreateReviewService();
            List<ReviewListItem> reviews = service.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet]
        public IHttpActionResult GetReviewById(int id)
        {
            ReviewService service = CreateReviewService();
            ReviewDetail review = service.GetReviewById(id);
            return Ok(review);
        }
    }
}
