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
    public class ShowController : ApiController
    {

        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var showService = new ShowService(userId);
            return showService;
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetShows();
            return Ok(shows);
        }

        [HttpPost]
        public IHttpActionResult PostShow(ShowCreate show)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var service = CreateShowService();

            if (!service.CreateShow(show))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetShowByTitle(string title)
        {
            ShowService showService = CreateShowService();
            var show = showService.GetShowByTitle(title);
            return Ok(show);
        }

    }
}
