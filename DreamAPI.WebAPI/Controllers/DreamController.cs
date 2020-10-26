using DreamAPI.Models;
using DreamAPI.Models.Dream;
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
    public class DreamController : ApiController
    {
        public IHttpActionResult Get()
        {
            DreamService dreamService = CreateDreamService();
            var dreams = dreamService.GetDreams();
            return Ok(dreams);
        }

        public IHttpActionResult Post(DreamCreate dream)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDreamService();

            if (!service.CreateDream(dream))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            DreamService dreamService = CreateDreamService();
            var dream = dreamService.GetDreamById(id);
            return Ok(dream);
        }

        public IHttpActionResult Put(DreamEdit dream)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDreamService();

            if (!service.UpdateDream(dream))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDreamService();

            if (!service.DeleteDream(id))
                return InternalServerError();

            return Ok();
        }

        private DreamService CreateDreamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dreamService = new DreamService(userId);
            return dreamService;
        }
    }
}