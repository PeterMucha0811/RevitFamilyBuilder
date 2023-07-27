using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.Models
{
    [Serializable]
    public class EG_Window
    {


        // Window Info Group
        // Dimensions Group


        public string Acronym { get; set; }
        public string Desc { get; set; }

        public bool IsFixed { get; set; }

        // IECC 2012-15 402.3.3.2 Increased SHGC (Checkbox)
        public bool IsIncreasedSHGC { get; set; }

        // Shading (Checkbox)
        public bool IsShaded { get; set; }
    }
}
