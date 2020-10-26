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

        public bool UpdateEmotion(EmotionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emotions
                        .Single(e => e.EmotionId == model.EmotionId && e.OwnerId == _userId);

                entity.EmotionType = model.EmotionType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmotion(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emotions
                        .Single(e => e.EmotionId == noteId && e.OwnerId == _userId);

                ctx.Emotions.Remove(entity);

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

        public EmotionDetail GetEmotionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emotions
                        .Single(e => e.EmotionId == id && e.OwnerId == _userId);
                return
                    new EmotionDetail()
                    {
                        EmotionId = entity.EmotionId,
                        EmotionType = entity.EmotionType,
                    };
            }
        }
    }
}