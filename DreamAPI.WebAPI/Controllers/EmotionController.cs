using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DreamAPI.Services;
using Microsoft.AspNet.Identity;

namespace DreamAPI.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        private EmotionService CreateNoteService()
        {
            var emotionId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new EmotionService(emotionId);
            return noteService;
        }
    }
}
