using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People;
using Hospital.Model.Cases;
using Hospital.DataAccess.Util;

namespace Hospital.Model.People.Patients
{
    public class Patient : Person
    {
        private Database _database;

        public int patientID { get; set; }
        public MedicalCard card { get; set; }
        public int medicalCardID { get; set; }
        public DateTime dateOfRegistration {get; set;}
        public List<Case> cases { get; set; }
        public bool currentlyUnderTreatment { get; set; }


        public Patient() : base() { this._database = new Database(); }

        public Patient(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email, DateTime dateOfRegistration) : base(name, surname, gender, dateOfBirth, mobileNumber, email) 
        {
            this._database = new Database();
            this.dateOfRegistration = dateOfRegistration;
            this.cases = new List<Case>();
        }

        public Patient(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email, DateTime dateOfRegistration, int patientID, int medicalCardID, Boolean underTreatment)
            : base(name, surname, gender, dateOfBirth, mobileNumber, email)
        {
            this._database = new Database();
            this.dateOfRegistration = dateOfRegistration;
            this.cases = new List<Case>();
            this.patientID = patientID;
            this.medicalCardID = medicalCardID;
            this.currentlyUnderTreatment = underTreatment;
        }


        public void setID(int id) 
        {
            this.patientID = id;
        }

        public void setMedicalCardID(int id)
        {
            this.medicalCardID = id;
        }


        public void addCase(Case caseObj) {
            this.cases.Add(caseObj);
        }
        
        public int getPatientIDFromDb() {

            int id;

            String query = String.Format("SELECT (patientID) FROM Patients WHERE name LIKE '{0}' AND surname LIKE '{1}' AND dateOfBirth LIKE '{2}'", this.name, this.surname, this.dateOfBirth.ToString("yyyy-MM-dd"));

            id = int.Parse(this._database.selectSingleQuery(query));

            return id;

        }

        public void startTreatment()
        {
            this.currentlyUnderTreatment = true;

            String query = String.Format("UPDATE Patients SET underTreatment='TRUE' WHERE patientID={0}", this.patientID);
            this._database.executeQuery(query);
        }

        public void endTreatment() 
        {
            this.currentlyUnderTreatment = false;

            String query = String.Format("UPDATE Patients SET underTreatment='FALSE' WHERE patientID={0}", this.patientID);
            this._database.executeQuery(query);
        }


    }
}
