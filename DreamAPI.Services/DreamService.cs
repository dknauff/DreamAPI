using DreamAPI.Data;
using DreamAPI.Models;
using DreamAPI.Models.Dream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Services
{
    public class DreamService
    {
        private readonly Guid _userId;

        public DreamService(Guid userID)
        {
            _userId = userID;
        }

        public bool CreateDream(DreamCreate model)
        {
            var entity =
                new Dream()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Location = model.Location,
                    Takeaway = model.Takeaway,
                    Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dreams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DreamListItem> GetDreams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dreams
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new DreamListItem
                                {
                                    DreamId = e.DreamId,
                                    Title = e.Title,
                                    Description = e.Description,
                                    Location = e.Location,
                                    Takeaway = e.Takeaway,
                                    Rating = e.Rating
                                }
                         );

                return query.ToArray();
            }
        }

        public DreamDetail GetDreamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dreams
                        .Single(e => e.DreamId == id && e.OwnerId == _userId);
                return
                    new DreamDetail
                    {
                        DreamId = entity.DreamId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Location = entity.Location,
                        Takeaway = entity.Takeaway,
                        Rating = entity.Rating
                    };
            }
        }

        public bool UpdateDream(DreamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dreams
                        .Single(e => e.DreamId == model.DreamId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Location = model.Location;
                entity.Takeaway = model.Takeaway;
                entity.Rating = model.Rating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDream(int dreamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dreams
                        .Single(e => e.DreamId == dreamId && e.OwnerId == _userId);

                ctx.Dreams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}