using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel.Helpers;
using Hospital.Model.Cases;

namespace Hospital.ViewModel.General.Appointments
{
    public class AppointmentViewModel : ObservableObject
    {
        private Appointment appointmentObj;

        public Appointment AppointmentObj
        {
            get
            { return appointmentObj; }
            set
            {
                appointmentObj = value;
                OnPropertyChanged("AppointmentObj");
            }
        }

        public int AppointmentID
        {
            get
            { return appointmentObj.appointmentID; }
            set
            {
                appointmentObj.appointmentID = value;
                OnPropertyChanged("AppointmentID");
            }
        }

        public int PatientID
        {
            get
            { return appointmentObj.patientID; }
            set
            {
                appointmentObj.patientID = value;
                OnPropertyChanged("PatientID");
            }
        }

         public int DoctorID
        {
            get
            { return appointmentObj.doctorID; }
            set
            {
                appointmentObj.doctorID = value;
                OnPropertyChanged("DoctorID");
            }
        }

         public int RoomNumber
        {
            get
            { return appointmentObj.roomNumber; }
            set
            {
                appointmentObj.roomNumber = value;
                OnPropertyChanged("RoomNumber");
            }
        }

         public DateTime Date
        {
            get
            { return appointmentObj.date; }
            set
            {
                appointmentObj.date = value;
                OnPropertyChanged("Date");
            }
        }

         public String Reason
        {
            get
            { return appointmentObj.reason; }
            set
            {
                appointmentObj.reason = value;
                OnPropertyChanged("Reason");
            }
        }

         public String PatientName
         {
             get
             { return appointmentObj.PatientName; }
             set
             {
                 appointmentObj.PatientName = value;
                 OnPropertyChanged("PatientName");
             }
         }

         public String DoctorName
         { 
             get
             { return appointmentObj.DoctorName; }
             set
             {
                 appointmentObj.DoctorName = value;
                 OnPropertyChanged("DoctorName");
             }
         }


        public AppointmentViewModel(Appointment obj) 
        {
             this.appointmentObj= new Appointment();
             AppointmentID = obj.appointmentID;
             PatientID = obj.patientID;
             DoctorID = obj.doctorID;
             RoomNumber = obj.roomNumber;
             Date = obj.date;
             Reason = obj.reason;
             appointmentObj.setPatientNameFromDb();
             appointmentObj.setDoctorNameFromDb();
        }

    }
   
}
