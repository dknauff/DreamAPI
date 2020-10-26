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
        private readonly Guid _emotionId;

        public EmotionService(Guid emotionId)
        {
            _emotionId = emotionId;
        }

        public bool CreateEmotion(EmotionCreate model)
        {
            var entity =
                new Emotion()
                {
                    DreamId = _emotionId,
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
                        .Where(e => e.DreamId == _emotionId)
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