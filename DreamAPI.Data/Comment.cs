using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string CommentDescription { get; set; }
        public int DreamId { get; set; }
        [ForeignKey(nameof(DreamId))]
        public virtual Dream Dream{ get; set; }
    }
}
