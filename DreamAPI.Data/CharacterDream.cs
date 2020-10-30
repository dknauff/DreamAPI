using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Data
{
    public class CharacterDream
    {
        public int CharacterId { get; set; }
        internal Character Character { get; set; }
        public Guid OwnerId { get; set; }
        public int DreamId { get; set; }
        internal Dream Dream { get; set; }
    }
}
