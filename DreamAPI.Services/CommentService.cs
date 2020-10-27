using DreamAPI.Data;
using DreamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DreamAPI.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    OwnerId = _userId,
                    CommentDescription = model.CommentDescription
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {

                                   CommentId = e.CommentId,
                                   CommentDescription = e.CommentDescription
                                }
                                );

                return query.ToArray();
            }
        }
        public CommentDetail GetCommentById(int id) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.OwnerId == _userId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentDescription = entity.CommentDescription
                    };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.OwnerId == _userId);

                entity.CommentDescription = model.CommentDescription;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int CommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == CommentId && e.OwnerId == _userId);

                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
