using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Cases
{
    public class Surgery
    {
        public int surgeryID { get; set; }
        public int patientID { get; set; }
        public int doctorID { get; set; }
        public int roomNumber { get; set; }
        public DateTime date { get; set; }
        public String type { get; set; }

        public void reschedule(DateTime date) { }
    }
}
