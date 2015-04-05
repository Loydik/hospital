using System;
using Hospital.DataAccess.Repositories;
using Hospital.Model.People.Patients;
using System.Collections.ObjectModel;
using Hospital.ViewModel.Helpers;

namespace Hospital.ViewModel.General.Patients
{
    public class PatientViewModel : ObservableObject
    {
        private Patient _patientObj;

        public Patient PatientObj
        {
            get
            { return _patientObj; }
            set
            {
                _patientObj = value;
                OnPropertyChanged("PatientObj");
            }
        }

        public String Name
        {
            get
            { return _patientObj.name; }
            set
            {
                _patientObj.name = value;
                OnPropertyChanged("Name");
            }
        }

        public String Surname
        {
            get
            { return _patientObj.surname; }
            set
            {
                _patientObj.surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public String Gender
        {
            get
            { return _patientObj.gender; }
            set
            {
                _patientObj.gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public DateTime DateOfBirth
        {
            get
            { return _patientObj.dateOfBirth; }
            set
            {
                _patientObj.dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public int MobileNumber
        {
            get
            { return _patientObj.mobileNumber; }
            set
            {
                _patientObj.mobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        public String Email
        {
            get
            { return _patientObj.email; }
            set
            {
                _patientObj.email = value;
                OnPropertyChanged("Email");
            }
        }

        public int PatientID
        {
            get
            { return _patientObj.patientID; }
            set
            {
                _patientObj.patientID = value;
                OnPropertyChanged("PatientID");
            }
        }

        public int MedicalCardID
        {
            get
            { return _patientObj.medicalCardID; }
            set
            {
                _patientObj.medicalCardID = value;
                OnPropertyChanged("MedicalCardID");
            }
        }

        public DateTime DateOfRegistration
        {
            get
            { return _patientObj.dateOfRegistration; }
            set
            {
                _patientObj.dateOfRegistration = value;
                OnPropertyChanged("DateOfRegistration");
            }
        }

        public Boolean CurrentlyUnderTreatment
        {
            get
            { return _patientObj.currentlyUnderTreatment; }
            set
            {
                _patientObj.currentlyUnderTreatment = value;
                OnPropertyChanged("CurrentlyUnderTreatment");
            }
        }

        public PatientViewModel(Patient obj) 
        {
             this._patientObj = new Patient();
             Name = obj.name;
             Surname = obj.surname;
             Gender = obj.gender;
             DateOfBirth = obj.dateOfBirth;
             DateOfRegistration = obj.dateOfRegistration;
             MobileNumber = obj.mobileNumber;
             Email = obj.email;
             CurrentlyUnderTreatment = obj.currentlyUnderTreatment;
             PatientID = obj.patientID;
             MedicalCardID = obj.medicalCardID;
        }

    }
}
