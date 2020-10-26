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
        [Required]
        public string EmotionType { get; set; }
        [Required]
        public int DreamId { get; set; }
    }
}