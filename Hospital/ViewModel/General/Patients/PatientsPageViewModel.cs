using Hospital.ViewModel.Helpers;
using System.Collections.ObjectModel;
using Hospital.Model.People.Patients;
using System.Windows.Input;
using Hospital.Model.People.Personel;
using Hospital.View.Reception;
using System;
using System.Linq;
using Hospital.DataAccess.Util;
using Hospital.ViewModel.Reception;
using Hospital.ViewModel.General.Samples;
using Hospital.View.DoctorsArea;
using Hospital.ViewModel.Laboratory;
using Hospital.View.Laboratory;
using Hospital.View;

namespace Hospital.ViewModel.General.Patients
{
    public class PatientsPageViewModel : ObservableObject, IPageViewModel
    {
        private ICommand _refreshCommand;
        private ICommand _showAllCommand;
        private ICommand _filterByLastNameCommand;
        private ICommand _addNewCaseCommand;
        private ICommand _writeEmailCommand;
        private ICommand _viewSamplesCommand;
        private ICommand _addSampleCommand;
        private IWindowFactory _windowFactory;
        private String _filterString;
        private String _filterMessage;
        private Receptionist _receptionist;
        private PatientsViewModel _viewModel;
        private ObservableCollection<PatientViewModel> _allPatients;
        private ObservableCollection<PatientViewModel> _patientsForDisplay;


        public PatientsPageViewModel()
        {
            _viewModel = new PatientsViewModel();
            _allPatients = _viewModel.AllPatients;
            _patientsForDisplay = _allPatients;
            _receptionist = new Receptionist();
            _windowFactory = new ProductionWindowFactory();
        }

        #region Properties

        public String Name
        {
            get
            {
                return "Patients";
            }
        }

        public String FilterString
        {
            get
            { return _filterString; }
            set
            {
                this._filterString = value.ToString().ToLower() ;
                OnPropertyChanged("FilterString");

            }
        }

        public String FilterMessage
        {
            get
            { return _filterMessage; }
            set
            {
                this._filterMessage = value;
                OnPropertyChanged("FilterMessage");

            }
        }

        public ObservableCollection<PatientViewModel> AllPatients { 
            get 
                { return _allPatients; }
            set
            {
                _allPatients = value;
                OnPropertyChanged("AllPatients");
            }
        }

        public ObservableCollection<PatientViewModel> PatientsForDisplay
        {
            get
            { return _patientsForDisplay; }
            set
            {
                _patientsForDisplay = value;
                OnPropertyChanged("PatientsForDisplay");
            }
        }

        #endregion Properties

        #region ICommands

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

        public ICommand FilterByLastNameCommand
        {
            get
            {
                if (_filterByLastNameCommand == null)
                {
                    _filterByLastNameCommand = new RelayCommand(
                        param => FilterByLastName(), param => FilterCommandCanExecute()
                    );
                }
                return _filterByLastNameCommand;
            }
        }

        public ICommand ShowAllCommand
        {
            get
            {
                if (_showAllCommand == null)
                {
                    _showAllCommand = new RelayCommand(
                        param => ShowAll(), param => ShowAllCanExecute()
                    );
                }
                return _showAllCommand;
            }
        }

        public ICommand AddNewCaseCommand
        {
            get
            {
                if (_addNewCaseCommand == null)
                {
                    _addNewCaseCommand = new RelayCommand(
                        param => _windowFactory.CreateNewWindow(new CaseAddPageViewModel((PatientViewModel) param), new CaseAddWindow())
                    );
                }
                return _addNewCaseCommand;
            }
        }

        public ICommand AddSampleCommand
        {
            get
            {
                if (_addSampleCommand == null)
                {
                    _addSampleCommand = new RelayCommand(
                       param => _windowFactory.CreateNewWindow(new SampleAddViewModel((PatientViewModel)param), new AddNewSample())
                    );
                }
                return _addSampleCommand;
            }
        }

        public ICommand ViewSamplesCommand
        {
            get
            {
                if (_viewSamplesCommand == null)
                {
                    _viewSamplesCommand = new RelayCommand(
                        param => _windowFactory.CreateNewWindow(new SamplesWindowViewModel((PatientViewModel)param), new SamplesWindow())
                    );
                }
                return _viewSamplesCommand;
            }
        }

        public ICommand WriteEmailCommand
        {
            get
            {
                if (_writeEmailCommand == null)
                {
                    _writeEmailCommand = new RelayCommand(
                        param => _windowFactory.CreateNewWindow(new WriteEmailViewModel((PatientViewModel)param), new WriteEmailWindow()), param => CanWriteEmailExecute()
                    );
                }
                return _writeEmailCommand;
            }
        }

        #endregion ICommands

        #region Methods

        public void FilterByLastName()
        {
            var result = _allPatients.Where(x => x.Surname.ToLower().Contains(_filterString)).ToList();
            PatientsForDisplay = new ObservableCollection<PatientViewModel>(result);
            FilterMessage = String.Format("Filtered by Last Name: {0}", FilterString);
            FilterString = "";

        }

        public bool FilterCommandCanExecute()
        {
            if (FilterString != null && FilterString != "")
            { return true; }
            else
            {
                return false;
            }
        }

        public void ShowAll()
        {
            PatientsForDisplay = AllPatients;
            FilterMessage = "";
        }

        public Boolean ShowAllCanExecute()
        {
            if (PatientsForDisplay != AllPatients)
            { return true; }
            else { return false; }
        }
        
        public void Refresh()
        {
            _viewModel.refresh();
            AllPatients = _viewModel.AllPatients;
            PatientsForDisplay = _allPatients;
        }

        public void WriteEmail()
        {
            EmailSender sender = new EmailSender();
            sender.sendEMailThroughGmail("vladik100x@gmail.com", "Test", "Test123");
        }

        public Boolean CanWriteEmailExecute()
        {
            return true;
        }

        #endregion Methods

    }
}
