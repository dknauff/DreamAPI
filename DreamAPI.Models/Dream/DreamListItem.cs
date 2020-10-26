using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Models
{
    public class DreamListItem
    {
        public int DreamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Takeaway { get; set; }
        public int Rating { get; set; }
    }
}