using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Cases;
using Hospital.Model.People.Patients;
using Hospital.Model.People;
using Hospital.DataAccess.Util;
using System.Threading;

namespace Hospital.Model.People.Personel
{
    public class Receptionist : Employee
    {
        private Database _database;

        public Receptionist()
            : base()
        {
            this._database = new Database();
        }
        
        public Receptionist(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email) : base(name, surname, gender, dateOfBirth, mobileNumber, email) 
        {
            this._database = new Database();
        }

        public void registerNewPatient(Patient patient) 
        {
            String query = String.Format("INSERT INTO Patients (name, surname, gender, dateOfBirth, mobileNumber, email, dateOfRegistration) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", patient.name, patient.surname, patient.gender, patient.dateOfBirth.ToString("yyyy-MM-dd"), patient.mobileNumber, patient.email, patient.dateOfRegistration.ToString("yyyy-MM-dd HH:mm:ss"));
            _database.executeQuery(query);

        }

        public void openNewCase(Case caseObj, Patient patient) 
        {
            String query = String.Format("INSERT INTO Cases (patientID, start_date, description) VALUES('{0}', '{1}', '{2}')", caseObj.patientID, caseObj.startDate.ToString("yyyy-MM-dd HH:mm:ss"), caseObj.description);
            _database.executeQuery(query);
           // patient.startTreatment();
        }

        public void removeCase(Case caseObj)
        {
            String query = String.Format("DELETE FROM Cases WHERE case_id={0}", caseObj.caseID);
            _database.executeQuery(query);
        }

        public void closePatientCase(Case caseObj, DateTime date)
        {
            String query = String.Format("UPDATE Cases SET end_date='{0}' WHERE case_id={1}", date.ToString("yyyy-MM-dd HH:mm:ss"), caseObj.getCaseIDFromDb());
            this._database.executeQuery(query);
        }

        public void scheduleAppointment(Appointment appointmentObj) 
        {

            String query = String.Format("INSERT INTO Appointments (patientID, doctorID, roomNumber, date, reason, caseID) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", appointmentObj.patientID, appointmentObj.doctorID, appointmentObj.roomNumber, appointmentObj.date.ToString("yyyy-MM-dd HH:mm:ss"), appointmentObj.reason, appointmentObj.caseID);

            _database.executeQuery(query);

        }

        public void createMedicalCard(MedicalCard medicalCardObj)
        {
            String query = String.Format("INSERT INTO Medical_cards (patientID) VALUES('{0}')", medicalCardObj.patientID);

            _database.executeQuery(query);
        }

        public void updatePatientMedicalCard(Patient patient, MedicalCard medicalCardObj)
        {
            String query = String.Format("UPDATE Patients SET medicalCardID={0} WHERE patientID={1}", medicalCardObj.getMedicalCardIDFromDb(), patient.getPatientIDFromDb());

            _database.executeQuery(query);
        }

        public void createAdmission(Patient patient, int bedNumber, Doctor doctor) 
        { 
            
        }

        public void printMedicalCardCopy(MedicalCard medCard) { }
        public List<Admission> getPatientAdmissionList(Patient patient) { return new List<Admission>(); }
        public List<Appointment> getPatientAppointmentList(Patient patient) { return new List<Appointment>(); }
        public void rescheduleAppointment(Appointment app, DateTime newDate) { }
        public void cancelAppointment(Appointment app) { }

    }
}
