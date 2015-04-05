using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Util;

namespace Hospital.Model.Laboratory
{
    public class Sample
    {
        private Database _database;

        public int sampleID { get; set; }
        public int patientID { get; set; }
        public int doctorID { get; set; }
        public DateTime creationDate { get; set; }
        public bool tested { get; set; }
        public int testedByLabWorkerID { get; set; }
        public String result { get; set; }

        public Sample() 
        {
            this._database = new Database();
        }

        public Sample(int patientID, int doctorID, DateTime creationDate, String result)
        {
            this.patientID = patientID;
            this.doctorID = doctorID;
            this.creationDate = creationDate;
            this.tested = true;
            this.result = result;
            this._database = new Database();
        }

        public void setResult(int labWorkerID, String result) {
            this.testedByLabWorkerID = labWorkerID;
            this.result = result;
        }

        public int getSampleIDFromDb()
        {
            int id;

            String query = String.Format("SELECT (sample_id) FROM Samples WHERE patient_id = '{0}' AND doctor_id = '{1}'", this.patientID, this.doctorID);

            id = int.Parse(this._database.selectSingleQuery(query));

            return id;

        }

    }
}
