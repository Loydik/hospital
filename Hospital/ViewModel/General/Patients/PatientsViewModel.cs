using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Repositories;
using Hospital.ViewModel.Helpers;
using System.Collections.ObjectModel;
using Hospital.Model.People.Patients;

namespace Hospital.ViewModel.General.Patients
{
    public class PatientsViewModel: ObservableObject
    {
        private PatientRepository _patientRepository;
        private ObservableCollection<PatientViewModel> _allPatients;


        public ObservableCollection<PatientViewModel> AllPatients
        {
            get
            { return _allPatients; }
            set
            {
                _allPatients = value;
                OnPropertyChanged("AllPatients");
            }
        }

        public PatientsViewModel()
        {
            this.init();
        }

        public void createObservablePatientsFromList(List<Patient> patients)
        {
            if (patients != null)
            {
                foreach (Patient patientObj in patients)
                {
                    _allPatients.Add(new PatientViewModel(patientObj));
                }
            }
        }

        private void init()
        {
            _patientRepository = new PatientRepository();
            _allPatients = new ObservableCollection<PatientViewModel>();

            if (_patientRepository == null)
            {
                throw new ArgumentNullException("Problem with fetching Data From Database");
            }

            this.createObservablePatientsFromList(_patientRepository.GetPatients());
        }

        public void refresh()
        {
            this.init();
            RaisePropertyChanged("AllPatients");
        }

    }
}
