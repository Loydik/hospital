using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel.Helpers;
using System.Windows.Input;
using Hospital.Model.People.Personel;
using Hospital.Model.Cases;
using MySql.Data.MySqlClient;
using System.Windows;
using Hospital.ViewModel.General.Patients;

namespace Hospital.ViewModel.Reception
{
    public class CaseAddPageViewModel : ObservableObject
    {
        private PatientsViewModel _patientsViewModel;
        private Receptionist _receptionist;
        private String _errorMessage;
        private PatientViewModel _patient;
        private String _patientName;
        private DateTime _now = DateTime.Now;
        private String _description;
        private ICommand _createNewCaseCommand;

        public CaseAddPageViewModel(PatientViewModel patient)
        {
            this._patient = patient;
            this._patientName = "" + patient.Name + " " + patient.Surname;
            this._receptionist = new Receptionist();
        }

        public PatientViewModel Patient
        {
            get
            { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged("Patient");
            }
        }

        public String PatientName
        {
            get
            { return _patientName; }
            set
            {
                _patientName = value;
                OnPropertyChanged("PatientName");
            }
        }

        public DateTime Now
        {
            get
            { return _now; }
            set
            {
                _now = value;
                OnPropertyChanged("Now");
            }
        }

        public String Description
       {
            get
            { return _description; }
            set
            {
                _description = value.ToString();
                OnPropertyChanged("Description");
            }
        }

        public String ErrorMessage
        {
            get
            { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public ICommand CreateNewCaseCommand
        {
            get
            {
                if (_createNewCaseCommand == null)
                {
                    _createNewCaseCommand = new RelayCommand(
                        param => CreateNewCase(), param => CreateNewCaseCanExecute()
                    );
                }
                return _createNewCaseCommand;
            }
        }


        public void CreateNewCase()
        {
            Case caseObj = new Case(_patient.PatientID, Now, Description);
           // try
            //{
                _receptionist.openNewCase(caseObj, _patient.PatientObj);

           // }
            //catch (MySqlException ex)
            //{
                ErrorMessage = "There was a problem with a database";
            //}

        }

        public Boolean CreateNewCaseCanExecute()
        {
            if (this._description != null && this._description != "" && this._patient != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
