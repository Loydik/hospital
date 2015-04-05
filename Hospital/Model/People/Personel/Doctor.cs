using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Cases;
using Hospital.Model.People.Patients;
using Hospital.DataAccess.Util;

namespace Hospital.Model.People.Personel
{
    public class Doctor : Employee
    {
        private Database _database;

        public int doctorID { get; set; }
        public String speciality { get; set; }
        public int roomNumber { get; set; }
        public List<Appointment> appointments;
        public List<Admission> admissions;

        public Doctor() : base()
        {
            this._database = new Database();
        }

        public Doctor(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email, String speciality, int roomNumber) : base(name, surname, gender, dateOfBirth, mobileNumber, email) 
        {
            this._database = new Database();
            this.speciality = speciality;
            this.roomNumber = roomNumber;
        }

        public String getLabTestResults(Patient patient) 
        {
            String query = String.Format("SELECT result FROM Samples WHERE patient_id={0} AND doctor_id={1} AND tested=TRUE", patient.getPatientIDFromDb(), this.doctorID);

            String result = this._database.selectSingleQuery(query);

            return result; 
        
        }

        public void declineAppointment(Appointment app) { }

        public void closePatientCase(Case caseObj, Patient patient, DateTime date)
        {
            String query = String.Format("UPDATE Cases SET end_date='{0}' WHERE case_id={1}", date.ToString("yyyy-MM-dd"), caseObj.getCaseIDFromDb());
            this._database.executeQuery(query);
            patient.endTreatment();
        }

        public void addEntryToMedicalCard(Entry entry) 
        {
            String query = String.Format("INSERT INTO Medical_card_entries (medical_card_id, date, doctorID, case_id, diagnosis, prescribed_drugs) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", entry.medicalCardID, entry.date.ToString("yyyy-MM-dd"), entry.doctorID, entry.caseID, entry.diagnosis, entry.prescribedDrugs);

            this._database.executeQuery(query);
        }

        public int getEmployeeID(int id)
        {
            String query = String.Format("SELECT employeeID FROM Doctors WHERE doctorID={0}", id);

            String result = this._database.selectSingleQuery(query);

            return Int32.Parse(result); 
        }
    }
}
