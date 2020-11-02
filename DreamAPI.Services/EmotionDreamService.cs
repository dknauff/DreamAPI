using DreamAPI.Data;
using DreamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Services
{
    public class EmotionDreamService
    {
        private readonly Guid _userId;

        public EmotionDreamService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateEmotionDream(EmotionDreamCreate model)
        {
            var entity =
                new EmotionDream()
                {
                    OwnerId = _userId,
                    EmotionId = model.EmotionId,
                    DreamId = model.DreamId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.EmotionDreams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
