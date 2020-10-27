using DreamAPI.Models.Emotion;
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
    public class EmotionController : ApiController
    {
        public IHttpActionResult Get()
        {
            EmotionService emotionService = CreateEmotionService();
            var emotions = emotionService.GetEmotions();
            return Ok(emotions);
        }
        public IHttpActionResult Get(int id)
        {
            EmotionService emotionService = CreateEmotionService();
            var emotion = emotionService.GetEmotionById(id);
            return Ok(emotion);
        }

        public IHttpActionResult Put(EmotionEdit emotion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmotionService();

            if (!service.UpdateEmotion(emotion))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEmotionService();

            if (!service.DeleteEmotion(id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Post(EmotionCreate emotion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmotionService();

            if (!service.CreateEmotion(emotion))
                return InternalServerError();

            return Ok();
        }
        private EmotionService CreateEmotionService()
        {
            var emotionId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new EmotionService(emotionId);
            return noteService;
        }
    }
}
