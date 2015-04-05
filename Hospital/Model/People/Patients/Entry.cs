using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.People.Patients
{
    public class Entry
    {
        public int entryID { get; set; }
        public int medicalCardID { get; set; }
        public DateTime date { get; set; }
        public int doctorID { get; set; }
        public int caseID { get; set; }
        public String diagnosis { get; set; }
        public String prescribedDrugs { get; set; }
  

        public Entry(int medicalCardID, DateTime date, int doctorID, int caseID, String diagnosis, String prescribedDrugs) 
        {
            this.medicalCardID = medicalCardID;
            this.date = date;
            this.doctorID = doctorID;
            this.caseID = caseID;
            this.diagnosis = diagnosis;
            this.prescribedDrugs = prescribedDrugs;
        }
    }
}
