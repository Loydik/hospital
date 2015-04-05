using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Util;

namespace Hospital.Model.Cases
{
    public class Case
    {
        private Database _database;

        public int caseID { get; set; }
        public int patientID { get; set; }
        public String patientName { get; set; }
        public String patientSurname { get; set; }
        public List<Admission> admissions { get; set; }
        public List<Appointment> appointments { get; set; }
        public List<Surgery> surgeries { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public String description { get; set; }

        public Case()
        {
            this._database = new Database();
        }

        public Case(int patientID, DateTime startDate, String description) 
        {
            this.patientID = patientID;
            this.startDate = startDate;
            this.description = description;
            this.appointments = new List<Appointment>();
            this.admissions = new List<Admission>();
            this.surgeries = new List<Surgery>();
            this._database = new Database();
        }

        public void addAppointment(Appointment appointmentObj)
        {
            this.appointments.Add(appointmentObj);
        }
        public void addAdmission(Admission adm) { }
        public void addSurgery(Surgery surgery) { }

        public int getCaseIDFromDb() 
        {
            int id;

            String query = String.Format("SELECT case_id FROM Cases WHERE patientID={0}", this.patientID);
            
            id = int.Parse(this._database.selectSingleQuery(query));

            return id;
        }

        public void setPatientNameFromDb()
        {
            String query = String.Format("SELECT name FROM Patients WHERE patientID={0}", this.patientID);
            this.patientName = this._database.selectSingleQuery(query);

        }

        public void setPatientSurnameFromDb()
        {
            String query = String.Format("SELECT surname FROM Patients WHERE patientID={0}", this.patientID);
            this.patientSurname = this._database.selectSingleQuery(query);
        }

        public void setEndDate(DateTime date)
        {
            this.endDate = date;   
        }

    }
}
