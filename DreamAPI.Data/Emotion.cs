using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Data
{
    public class Emotion
    {
        [Key]
        public int EmotionId { get; set; }
        public string EmotionType { get; set; }
        public Guid OwnerId { get; set; }
    }
}