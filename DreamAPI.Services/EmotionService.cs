using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Services
{
    public class EmotionService
    {
        private readonly Guid _emotionId;

        public EmotionService(Guid emotionId)
        {
            _emotionId = emotionId;
        }
    }
}
