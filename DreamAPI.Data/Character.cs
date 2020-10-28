using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }        
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Relationship { get; set; }
    }
}
