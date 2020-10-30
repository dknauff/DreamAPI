using DreamAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models.Character1
{
    public class CharacterListItem
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Relationship { get; set; }
        public virtual ICollection<Dream> Dreams { get; set; }
    }
}
