using Hospital.ViewModel.General.Appointments;
using Hospital.ViewModel.General.Patients;
using Hospital.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hospital.Model.People.Personel;
using Hospital.Model.Laboratory;

namespace Hospital.ViewModel.Laboratory
{
    public class SampleAddViewModel : ObservableObject
    {
        private int _selectedDoctorID; // Has a default value of 0!!!!
        private String _patientName;
        private DoctorsViewModel _doctorsVM;
        private ObservableCollection<DoctorViewModel> _allDoctors;
        private DateTime _sampleDate = DateTime.Now;
        private String _result;
        private ICommand _addCaseCommand;
        private LabWorker _labWorker;
        private PatientViewModel _patient;

        public SampleAddViewModel(PatientViewModel patient)
        {
            this._patient = patient;
            _patientName = patient.Name + " " + patient.Surname;
            this._doctorsVM = new DoctorsViewModel();
            this._allDoctors = _doctorsVM.AllDoctors;
            _labWorker = new LabWorker();
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

        public ObservableCollection<DoctorViewModel> Doctors
        {
            get
            { return _allDoctors; }
            set
            {
                _allDoctors = value;
                OnPropertyChanged("Doctors");
            }
        }

        public int SelectedDoctorID
        {
            get
            { return _selectedDoctorID; }
            set
            {
                _selectedDoctorID = value;
                OnPropertyChanged("SelectedDoctorID");
            }
        }

        public DateTime SampleDate
        {
            get
            { return _sampleDate; }
            set
            {
                _sampleDate = value;
                OnPropertyChanged("SampleDate");
            }
        }

        public String Result
        {
            get
            { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public ICommand AddCaseCommand
        {
            get
            {
                if (_addCaseCommand == null)
                {
                    _addCaseCommand = new RelayCommand(
                        param => AddCase(), param => AddCaseCommandCanExecute()
                    );
                }
                return _addCaseCommand;
            }
        }

        public void AddCase()
        {
            Sample sampleObj = new Sample(_patient.PatientID, _selectedDoctorID, _sampleDate, _result);
            _labWorker.registerNewSample(sampleObj);
        }

        public Boolean AddCaseCommandCanExecute()
        {
            if (this.checkDoctorID() && this.checkResult())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkResult()
        {
            if (_result != null && _result != "")
            {
                return true;
            }
            else { return false; }
        }

        public Boolean checkDoctorID()
        {
            if (_selectedDoctorID != 0)
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
