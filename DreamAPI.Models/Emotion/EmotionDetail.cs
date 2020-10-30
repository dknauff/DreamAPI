using DreamAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models.Emotion1
{
    public class EmotionDetail
    {
        public int EmotionId { get; set; }
        public string EmotionType { get; set; }

        public ICollection<Dream> Dreams { get; set; }
    }
}
