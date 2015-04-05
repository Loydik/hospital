using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Util;
using Hospital.Model.People.Personel;

namespace Hospital.Model.Cases
{
    public class Appointment
    {
        private Database _database;
        public int appointmentID { get; set; }
        public int patientID { get; set; }
        public int doctorID { get; set; }
        public int roomNumber { get; set; }
        public DateTime date { get; set; }
        public String reason { get; set; }
        public int caseID { get; set; }

        public String PatientName
        {
            get;
            set;
        }

        public String DoctorName
        {
            get;
            set;
        }

        public Appointment()
        {
            this._database = new Database();
        }

        public Appointment(int patientID, int doctorID, int roomNumber, DateTime date, String reason, int caseId) 
        {
            this.patientID = patientID;
            this.doctorID = doctorID;
            this.roomNumber = roomNumber;
            this.date = date;
            this.reason = reason;
            this._database = new Database();
            this.caseID = caseId;
            setPatientNameFromDb();
            setDoctorNameFromDb();
        }

        public void changeDate(DateTime date) { }

        public void setPatientNameFromDb()
        {
            String query = String.Format("SELECT name, surname FROM Patients WHERE patientID={0}", this.patientID);
            String[,] credentials = this._database.selectQuery(query, new List<string>() { "name", "surname"});
            PatientName = credentials[0,0] + " " + credentials[0,1];
        }

        public void setDoctorNameFromDb()
        {
            Doctor temp = new Doctor();
            int employeeID = temp.getEmployeeID(this.doctorID);
            String query = String.Format("SELECT name, surname FROM Employees WHERE employeeID={0}", employeeID);
            String[,] credentials = this._database.selectQuery(query, new List<string>() { "name", "surname"});
            DoctorName = credentials[0, 0] + " " + credentials[0, 1];
        }
    }
}
