using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models
{
    public class CommentDelete
    {
        public int CommentId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
