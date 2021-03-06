﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Data
{
    public class Dream
    {
        [Key]
        public int DreamId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Location { get; set; }
        public string Takeaway { get; set; }
        public int Rating { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<EmotionDream> EmotionDreams { get; set; } = new HashSet<EmotionDream>();

        public ICollection<CharacterDream> CharacterDreams { get; set; } = new HashSet<CharacterDream>();
    }
}