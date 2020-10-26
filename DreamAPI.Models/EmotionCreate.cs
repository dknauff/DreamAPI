using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models
{
    public class EmotionCreate
    {
        [Required]
        public string EmotionType { get; set; }
    }
}
