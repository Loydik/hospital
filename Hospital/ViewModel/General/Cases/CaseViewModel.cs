using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Cases;
using Hospital.ViewModel.Helpers;

namespace Hospital.ViewModel.General.Cases
{
    public class CaseViewModel : ObservableObject
    {
        private Case caseObj;

        public Case CaseObj
        {
            get
            { return caseObj; }
            set
            {
                caseObj = value;
                OnPropertyChanged("CaseObj");
            }
        }

        public int CaseID
        {
            get
            { return caseObj.caseID; }
            set
            {
                caseObj.caseID = value;
                OnPropertyChanged("CaseID");
            }
        }

        public int PatientID
        {
            get
            { return caseObj.patientID; }
            set
            {
                caseObj.patientID = value;
                OnPropertyChanged("PatientID");
            }
        }

        public String PatientName
        {
            get
            { return caseObj.patientName; }
            set
            {
                caseObj.patientName = value;
                OnPropertyChanged("PatientName");
            }
        }

        public String PatientSurname
        {
            get
            { return caseObj.patientSurname; }
            set
            {
                caseObj.patientSurname = value;
                OnPropertyChanged("PatientSurname");
            }
        }

        public DateTime StartDate
        {
            get
            { return caseObj.startDate; }
            set
            {
                caseObj.startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public DateTime? EndDate
        {
            get
            { return caseObj.endDate; }
            set
            {
                caseObj.endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public String Description
        {
            get
            { return caseObj.description; }
            set
            {
                caseObj.description = value;
                OnPropertyChanged("Description");
            }
        }

        public CaseViewModel(Case obj) 
        {
             obj.setPatientNameFromDb();
             obj.setPatientSurnameFromDb();

             this.caseObj = new Case();
             CaseID = obj.caseID;
             PatientID = obj.patientID;
             StartDate = obj.startDate;
             EndDate = obj.endDate;
             Description = obj.description;
             PatientName = obj.patientName;
             PatientSurname = obj.patientSurname;
        }

    }
}
