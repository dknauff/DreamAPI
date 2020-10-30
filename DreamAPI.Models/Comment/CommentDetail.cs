using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string CommentDescription { get; set; }
        public int DreamId { get; set; }
    }
}