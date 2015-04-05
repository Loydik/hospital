using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People.Personel;
using Hospital.ViewModel.Helpers;

namespace Hospital.ViewModel.General.Appointments
{
    public class DoctorViewModel : ObservableObject
    {
        private Doctor docObj;
        private String _fullName;
        private String _speciality;
        private String _fullInfo;
        private int _roomNumber;
        private int _doctorID;

        public Doctor DocObj
        {
            get
            { return docObj; }
            set
            {
                docObj = value;
                OnPropertyChanged("DocObj");
            }
        }

        public int DoctorID
        {
            get
            { return _doctorID; }
            set
            {
                _doctorID = value;
                OnPropertyChanged("DoctorID");
            }
        }

        public String FullName
        {
            get
            { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public String FullInfo
        {
            get
            { return _fullInfo; }
            set
            {
                _fullInfo = value;
                OnPropertyChanged("FullInfo");
            }
        }

        public int RoomNumber
        {
            get
            { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged("RoomNumber");
            }
        }

        public String Speciality
        {
            get
            { return _speciality; }
            set
            {
                _speciality = value;
                OnPropertyChanged("Speciality");
            }
        }

        public DoctorViewModel(Doctor obj)
        {
            this.docObj = obj;
            this._doctorID = obj.doctorID;
            this._fullName = obj.name + " " + obj.surname;
            this._speciality = obj.speciality;
            this._roomNumber = obj.roomNumber;
            FullInfo = _fullName + ", " + _speciality;
        }
    }
}
