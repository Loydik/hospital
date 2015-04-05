using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Infrastructure
{
    public class SurgeryRoom : Room
    {
        public bool occupied { get; set; }
        public string equipment { get; set; }
    }
}
