using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel.Helpers;
using Hospital.Model.People.Personel;
using Hospital.DataAccess.Repositories;
using System.Collections.ObjectModel;
using Hospital.DataAccess.Util.ListCreators;
using System.Windows.Input;
using System.Globalization;
using Hospital.DataAccess;
using Hospital.DataAccess.Util;
using Hospital.Model.Cases;
using Hospital.ViewModel.General.Cases;
using Hospital.ViewModel.General.Appointments;

namespace Hospital.ViewModel.Reception
{
    public class ScheduleAppointmentWindowViewModel : ObservableObject
    {
        private Database _database;
        private CaseViewModel _caseViewModel;
        private DoctorsViewModel _doctorsVM;
        private String _patientName;
        private String _errorMessage;
        private DateTime _appointmentDateTime;
        private Receptionist _receptionist;
        private ObservableCollection<DoctorViewModel> _allDoctors;
        private int _selectedDoctorID; // Has a default value of 0!!!!
        private ObservableCollection<String> _appointmentTimes;
        private String _reason;
        private DateTime _appointmentDate = DateTime.Now;
        private String _selectedTime;
        private ICommand _scheduleAppointmentCommand;
        
        public ScheduleAppointmentWindowViewModel(CaseViewModel caseVM)
        {
            this._caseViewModel = caseVM;
            this._database = new Database();
            this._doctorsVM = new DoctorsViewModel();
            this._allDoctors = _doctorsVM.AllDoctors;
            _patientName = caseVM.PatientName + " " + caseVM.PatientSurname;
            _receptionist = new Receptionist();
            List<String> appointmentTimes = this.getListOfAppointmentTimes();
            _appointmentTimes = this.createObservableCollectionOfAppointmentTimes(appointmentTimes);
            
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

        public String SelectedTime
        {
            get
            { return _selectedTime; }
            set
            {
                _selectedTime = value;
                OnPropertyChanged("SelectedTime");
            }
        }

        public String Reason
        {
            get
            { return _reason; }
            set
            {
                _reason = value;
                OnPropertyChanged("Reason");
            }
        }

        public DateTime AppointmentDate
        {
            get
            { return _appointmentDate; }
            set
            {
                _appointmentDate = value;
                OnPropertyChanged("AppointmentDate");
            }
        }

        public DateTime AppointmentDateTime
        {
            get
            { return _appointmentDateTime; }
            set
            {
                _appointmentDateTime = value;
                OnPropertyChanged("AppointmentDateTime");
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

        public ObservableCollection<String> AppointmentTimes
        {
            get
            { return _appointmentTimes; }
            set
            {
                _appointmentTimes = value;
                OnPropertyChanged("AppointmentTimes");
            }
        }

        public List<String> getListOfAppointmentTimes()
        {
            AppointmentTimesListCreator _listCreator = new AppointmentTimesListCreator();
            List<String> result = _listCreator.createListOfAppointmentTimes("SELECT * FROM Appointments_times");
            return result;
        }

        public ObservableCollection<String> createObservableCollectionOfAppointmentTimes(List<String> obj)
        {
            ObservableCollection<String> times = new ObservableCollection<String>();

            foreach (String time in obj)
            {
                times.Add(time);
            }

            return times;
        }

        public ICommand ScheduleAppointmentCommand
        {
            get
            {
                if (_scheduleAppointmentCommand == null)
                {
                    _scheduleAppointmentCommand = new RelayCommand(
                        param => ScheduleAppointment(), param => ScheduleAppointmentCanExecute()
                    );
                }
                return _scheduleAppointmentCommand;
            }
        }

        public void ScheduleAppointment()
        {
            if (this.checkForDuplicateAppointments())
            { ErrorMessage = "This Time is already occupied"; }
            else
            {
                Appointment appObj = new Appointment(_caseViewModel.PatientID, _selectedDoctorID, getDoctorRoom(_selectedDoctorID), _appointmentDateTime, _reason, _caseViewModel.CaseID);
                _receptionist.scheduleAppointment(appObj);
            }
        }

        public Boolean ScheduleAppointmentCanExecute()
        {
            if (this.checkDoctorID() && this.checkReason() && this.checkAppointmentDate())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkForDuplicateAppointments()
        {
            String query = String.Format("SELECT * FROM Appointments WHERE date LIKE '{0}'", _appointmentDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "%");
            String result = _database.selectSingleQuery(query);

            if (result == "")
            { return false; }
            else
            { return true; }
        }

        public Boolean checkReason()
        {
            if (_reason != null && _reason != "")
            {
                return true;
            }
            else { return false; }
        }

        public Boolean checkSelectedTime()
        {
            if (_selectedTime != null && _selectedTime != "")
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

        public Boolean checkAppointmentDate()
        {
            this.parseDateAndTime(_appointmentDate, _selectedTime);

            if (_appointmentDateTime <= DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int getDoctorRoom(int id)
        {
            IEnumerable<Int32> result = _allDoctors.Where(DoctorViewModel => DoctorViewModel.DoctorID == id).Select(DoctorViewModel => DoctorViewModel.RoomNumber);
            return result.First();
        }

        public void parseDateAndTime(DateTime date, String time)
        {
            String dateString = date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime newDateTime = DateTime.Parse(dateString + " " + time, CultureInfo.InvariantCulture);
            AppointmentDateTime = newDateTime;
        }
    }
}
