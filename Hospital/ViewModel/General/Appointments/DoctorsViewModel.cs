using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hospital.ViewModel.Helpers;
using Hospital.DataAccess.Repositories;
using Hospital.Model.People.Personel;

namespace Hospital.ViewModel.General.Appointments
{
    public class DoctorsViewModel : ObservableObject
    {
        private DoctorsRepository _repository;

        private ObservableCollection<DoctorViewModel> _allDoctors;

        public ObservableCollection<DoctorViewModel> AllDoctors
        {
            get
            { return _allDoctors; }
            set
            {
                _allDoctors = value;
                OnPropertyChanged("AllDoctors");
            }
        }

        public DoctorsViewModel()
        {
            _repository = new DoctorsRepository();
            _allDoctors = new ObservableCollection<DoctorViewModel>();

            if (_repository == null)
            {
                throw new ArgumentNullException("Problem with fetching Data From Database");
            }

            this.createObservableDoctorsFromList(_repository.GetDoctors("SELECT * FROM Doctors a, Employees b WHERE a.employeeID = b.employeeID"));
        }

        public void createObservableDoctorsFromList(List<Doctor> doctors)
        {
            if (doctors != null)
            {
                foreach (Doctor obj in doctors)
                {
                    _allDoctors.Add(new DoctorViewModel(obj));
                }
            }
        }

    }
}
