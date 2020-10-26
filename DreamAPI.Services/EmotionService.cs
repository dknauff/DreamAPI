using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamAPI.Data;
using DreamAPI.Models;

namespace DreamAPI.Services
{
    public class EmotionService
    {
        private readonly Guid _userId;

        public EmotionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmotion(EmotionCreate model)
        {
            var entity =
                new Emotion()
                {
                    OwnerId = _userId,
                    EmotionType = model.EmotionType,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Emotions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmotionList> GetEmotions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Emotions
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EmotionList()
                                {
                                    EmotionId = e.EmotionId,
                                    EmotionType = e.EmotionType,
                                }
                        );

                return query.ToArray();
            }
        }
    }
}