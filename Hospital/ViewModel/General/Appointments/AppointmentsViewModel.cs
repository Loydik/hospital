using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel.Helpers;
using Hospital.DataAccess.Repositories;
using System.Collections.ObjectModel;
using Hospital.Model.Cases;

namespace Hospital.ViewModel.General.Appointments
{
    public class AppointmentsViewModel : ObservableObject
    {
        private AppointmentsRepository _appointmentsRepository;
        String _allAppointmentsQuery = "SELECT * FROM Appointments";
        private ObservableCollection<AppointmentViewModel> _allAppointments;

        public ObservableCollection<AppointmentViewModel> AllAppointments
        {
            get
            { return _allAppointments; }
            set
            {
                _allAppointments = value;
                OnPropertyChanged("AllAppointments");
            }
        }

        public AppointmentsViewModel()
        {
            this.init();
        }

        public void createObservableAppointmentsFromList(List<Appointment> appointments)
        {
            if (appointments != null)
            {
                foreach (Appointment appointmentObj in appointments)
                {
                    AllAppointments.Add(new AppointmentViewModel(appointmentObj));
                }
            }
        }

        private void init()
        {
            _appointmentsRepository = new AppointmentsRepository();
            _allAppointments = new ObservableCollection<AppointmentViewModel>();

            if (_appointmentsRepository == null)
            {
                throw new ArgumentNullException("Problem with fetching Data From Database");
            }

            this.createObservableAppointmentsFromList(_appointmentsRepository.GetAppointments(_allAppointmentsQuery));
        }

        public void refresh()
        {
            this.init();
            RaisePropertyChanged("AllAppointments");
        }
    }
}
