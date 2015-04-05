using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Laboratory;
using Hospital.Model.People.Patients;
using Hospital.DataAccess.Util;

namespace Hospital.Model.People.Personel
{
    public class LabWorker : Employee
    {
        private Database _database;

        public int labWorkerID { get; set; }
        public List<Sample> untestedSamples { get; set; }

        public LabWorker()
        {
            this._database = new Database();
        }

         public LabWorker(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email) : base(name, surname, gender, dateOfBirth, mobileNumber, email) 
        {
            this.untestedSamples = new List<Sample>();
            this._database = new Database();
        }

        public void registerNewSample(Sample sampleObj) 
        {
            String query = String.Format("INSERT INTO Samples (patient_id, doctor_id, creation_date, result) VALUES('{0}', '{1}', '{2}', '{3}')", sampleObj.patientID, sampleObj.doctorID, sampleObj.creationDate.ToString("yyyy-MM-dd"), sampleObj.result);

            this._database.executeQuery(query);
        }

        public void saveTestResult(Sample sampleObj, String result) 
        {
            sampleObj.setResult(this.labWorkerID, result);
        }

        public void saveTestResultToDb(Sample sampleObj) 
        {
            String query = String.Format("UPDATE Samples SET tested='TRUE', tested_by_lab_worker_id={0}, result='{1}' WHERE sample_id={2}", this.labWorkerID, sampleObj.result, sampleObj.getSampleIDFromDb());

            this._database.executeQuery(query);
        }
    }
}
