using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Cases
{
    public class Admission
    {
        public int admissionID { get; set; }
        public int patientID { get; set; }
        public int doctorID { get; set; }
        public int bedNumber { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String justification { get; set; }

        public void extendAdmission(DateTime endDate) { }
    }
}
