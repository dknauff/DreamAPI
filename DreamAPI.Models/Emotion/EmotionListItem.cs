using DreamAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models.Emotion1
{
    public class EmotionListItem
    {
        public int EmotionId { get; set; }
        public string EmotionType { get; set; }

        public virtual ICollection<EmotionDream> EmotionDreams { get; set; }
    }
}
