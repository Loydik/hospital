using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel.Helpers;
using System.Collections.ObjectModel;
using Hospital.Model.Cases;
using System.Windows.Input;
using Hospital.Model.People.Personel;
using Hospital.View.Reception;

namespace Hospital.ViewModel.General.Appointments
{
    public class AppointmentsPageViewModel : ObservableObject, IPageViewModel
    {
        private AppointmentsViewModel _viewModel;
        private ObservableCollection<AppointmentViewModel> _allAppointments;
        private ObservableCollection<AppointmentViewModel> _appointmentsForDisplay;
        private Receptionist _receptionist;
        private ProductionWindowFactory _windowFactory;
        private ICommand _refreshCommand;

        public string Name
        {
            get { return "Appointments Page"; }
        }

        public AppointmentsPageViewModel()
        {
            _viewModel = new AppointmentsViewModel();
            _allAppointments = _viewModel.AllAppointments;
            _appointmentsForDisplay = _allAppointments;
            _receptionist = new Receptionist();
            _windowFactory = new ProductionWindowFactory();
        }

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

        public ObservableCollection<AppointmentViewModel> AppointmentsForDisplay
        {
            get
            { return _appointmentsForDisplay; }
            set
            {
                _appointmentsForDisplay = value;
                OnPropertyChanged("AppointmentsForDisplay");
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new RelayCommand(
                        param => Refresh()
                    );
                }
                return _refreshCommand;
            }
        }

        public void Refresh()
        {
            _viewModel.refresh();
            AllAppointments = _viewModel.AllAppointments;
            AppointmentsForDisplay = AllAppointments;
        }
    }
}
