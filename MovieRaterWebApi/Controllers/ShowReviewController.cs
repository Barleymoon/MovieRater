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
    public class ShowReviewController : ApiController
    {
        [Authorize]

        private ShowReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            ShowReviewService service = new ShowReviewService(userId);
            return service;
        }

        [HttpPost]
        public IHttpActionResult PostReview(ShowReviewCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShowReviewService service = CreateReviewService();
            if (!service.CreateReview(model))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllReviews()
        {
            ShowReviewService service = CreateReviewService();
            List<ShowReviewListItem> reviews = service.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet]
        public IHttpActionResult GetReviewById(int id)
        {
            ShowReviewService service = CreateReviewService();
            ReviewDetail review = service.GetReviewById(id);
            return Ok(review);
        }
    }
}
