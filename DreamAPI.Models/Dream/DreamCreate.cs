using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models
{
    public class DreamCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Takeaway { get; set; }
        [Range(1, 5, ErrorMessage = "Please choose a number between 1 and 5")]
        public int Rating { get; set; }

        
    }
}
