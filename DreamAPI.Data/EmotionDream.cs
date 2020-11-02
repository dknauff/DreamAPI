using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Data
{
    public class EmotionDream
    {
        public int EmotionId { get; set; }
        internal Emotion Emotion { get; set; }
        public Guid OwnerId { get; set; }
        public int DreamId { get; set; }
        internal Dream Dream { get; set; }
    }
}