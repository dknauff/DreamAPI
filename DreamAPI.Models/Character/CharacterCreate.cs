using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models.Character1
{
    public class CharacterCreate
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Relationship { get; set; }
    }
}
