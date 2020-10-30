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
    public class CharacterDreamController : ApiController
    {
        public IHttpActionResult Post(CharacterDreamCreate dream)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCharacterDreamService();

            if (!service.CreateCharacterDream(dream))
                return InternalServerError();

            return Ok();
        }

        private CharacterDreamService CreateCharacterDreamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dreamCharacterService = new CharacterDreamService(userId);
            return dreamCharacterService;
        }
    }
}
