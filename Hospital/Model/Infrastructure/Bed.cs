using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Infrastructure
{
    public class Bed
    {
        public int roomNumber { get; set; }
        public int bedNumber { get; set; }
        public bool occupied { get; set; }
        public bool lifeSupportUnit { get; set; }
        public int patientID { get; set; }
    }
}
