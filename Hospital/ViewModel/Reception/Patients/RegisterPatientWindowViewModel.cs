using System;
using Hospital.ViewModel.Helpers;
using Hospital.Model.People.Patients;
using Hospital.Model.People.Personel;
using System.Windows.Input;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Hospital.ViewModel.Reception
{
    public class RegisterPatientWindowViewModel : ObservableObject
    {
        #region Fields

        private Patient _patient;
        private MedicalCard _medicalCard;
        private ICommand _registerNewPatient;
        private Receptionist _receptionist;

        private String _name;
        private String _surname;
        private String _gender;
        private DateTime _dateOfBirth = DateTime.Now;
        private String _email;
        private Int32? _mobileNumber;
        private String _errorMessage;

        #endregion Fields

        #region Properties

        public String Name
        {
            get { return _name; }
            set
            {
                if (value != null && value != "")
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
                else { ErrorMessage = "First Name cannot be empty"; }
            }
        }

        public String Surname
        {
            get { return _surname; }
            set
            {
                if (value != null && value != "")
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                }
                else { ErrorMessage = "Last Name cannot be empty"; }
            }
        }

        public String Gender
        {
            get { return _gender; }
            set
            {
                if (value != null && value != "")
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public String Email
        {
            get { return _email; }
            set
            {
                if (this.isValidEmail(value))
                {
                    _email = value;
                    ErrorMessage = "";
                    OnPropertyChanged("Email");
                }
                else { ErrorMessage = "Incorrect Email Format"; }
            }
        }

        public Int32? MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                int x;

                if (value != null && (int.TryParse(value.ToString(), out x)))
                {
                    _mobileNumber = value;
                    OnPropertyChanged("MobileNumber");
                }
                else { ErrorMessage = "Mobile Number cannot be empty"; }
            }
        }

        public String ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value != null)
                {
                    _errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        public Patient Patient
        {
            get { return _patient; }
            set
            { OnPropertyChanged("Patient"); }
        }

        public ICommand RegisterNewPatientCommand
        {
            get
            {
                if (_registerNewPatient == null)
                {
                    _registerNewPatient = new RelayCommand(
                        param => registerNewPatient(), param => canRegisterCommand()
                    );
                }
                return _registerNewPatient;
            }
        }

        #endregion Properties

        public void registerNewPatient()
        {
            DateTime now = DateTime.Now;
            _patient = new Patient(Name, Surname, Gender, DateOfBirth, Convert.ToInt32(MobileNumber), Email, now);
            _receptionist = new Receptionist();

            try
            {
                _receptionist.registerNewPatient(_patient);
                _medicalCard = new MedicalCard(_patient.getPatientIDFromDb());
                _receptionist.createMedicalCard(_medicalCard);
                _receptionist.updatePatientMedicalCard(_patient, _medicalCard);
                CloseAction.Invoke();
            }
            catch (MySqlException ex)
            {
                ErrorMessage = "Problem with writing data(MySQLException)";
            }
        }

        public bool isValidEmail(String emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool canRegisterCommand()
        {
            if (_name != null && _surname != null && _gender != null && _email != null && _mobileNumber != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Action CloseAction { get; set; }

        
    }
}
