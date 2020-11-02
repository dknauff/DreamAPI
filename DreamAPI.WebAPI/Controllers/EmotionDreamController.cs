using DreamAPI.Models;
using DreamAPI.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DreamAPI.WebAPI.Controllers
{
    [Authorize]
    public class EmotionDreamController : ApiController
    {
        public IHttpActionResult Post (EmotionDreamCreate dream)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmotionDreamService();

            if (!service.CreateEmotionDream(dream))
                return InternalServerError();

            return Ok();
        }

        private EmotionDreamService CreateEmotionDreamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var emotionDreamService = new EmotionDreamService(userId);
            return emotionDreamService;
        }
    }
}
