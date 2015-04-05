using Hospital.ViewModel.General.Patients;
using Hospital.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hospital.DataAccess.Util;

namespace Hospital.ViewModel.General
{
    public class WriteEmailViewModel : ObservableObject
    {
        private PatientViewModel _patient;
        private String _patientName;
        private String _topic;
        private String _content;
        private ICommand _sendEmailCommand;


        public WriteEmailViewModel(PatientViewModel patient)
        {
            this._patient = patient;
            this._patientName = patient.Name + " " + patient.Surname;
        }

        public String PatientName
        {
            get
            {
                return _patientName;
            }
            set
            {
                _patientName = value;
                OnPropertyChanged("PatientName");
            }
        }

        public String Email
        {
            get
            {
                return _patient.Email;
            }
            set
            {
                _patient.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public String Topic
        {
            get
            {
                return _topic;
            }
            set
            {
                _topic = value;
                OnPropertyChanged("Topic");
            }
        }

        public String Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public ICommand SendEmailCommand
        {
            get
            {
                if (this._sendEmailCommand == null)
                {
                    _sendEmailCommand = new RelayCommand(
                        param => SendEmail(), param => SendEmailCommandCanExecute()
                    );
                }
                return _sendEmailCommand;
            }
        }

        public void SendEmail()
        {
            EmailSender sender = new EmailSender();
            sender.sendEMailThroughGmail(this.Email, this.Topic, this.Content);
        }

        public Boolean SendEmailCommandCanExecute()
        {
            if (this._content != "" && this._topic != "" && this._content != null && this._topic != null)
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
