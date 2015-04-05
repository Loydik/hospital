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
using Hospital.ViewModel.Reception;

namespace Hospital.ViewModel.General.Cases
{
    public class CasesPageViewModel : ObservableObject, IPageViewModel
    {
        private CasesViewModel _viewModel;
        private ObservableCollection<CaseViewModel> _cases;
        private ObservableCollection<CaseViewModel> _casesForDisplay;
        private String _filterString;
        private Receptionist _receptionist;
        private ICommand _closeCaseCommand;
        private ICommand _removeCaseCommand;
        private ICommand _filterByLastNameCommand;
        private ICommand _refreshCommand;
        private ICommand _showAllCommand;
        private ICommand _scheduleAppointmentCommand;
        private String _filterMessage;
        private IWindowFactory _windowFactory;
        

        public CasesPageViewModel()
        {
            this._viewModel = new CasesViewModel();
            this._cases = _viewModel.AllCases;
            this._casesForDisplay = this._cases;
            this._receptionist = new Receptionist();
            this._windowFactory = new ProductionWindowFactory();
        }

        public string Name
        {
            get { return "Cases Page"; }
        }

        public ObservableCollection<CaseViewModel> Cases
        {
            get
            { return _cases; }
            set
            {
                this._cases = value;
                OnPropertyChanged("Cases");
            }
        }

        public ObservableCollection<CaseViewModel> CasesForDisplay
        {
            get
            { return _casesForDisplay ; }
            set
            {
                this._casesForDisplay = value;
                OnPropertyChanged("CasesForDisplay");
            }
        }
        
        public String FilterString
        {
            get
            { return _filterString; }
            set
            {
                    this._filterString = value.ToString().ToLower();
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

        public ICommand ScheduleAppointmentCommand
        {
            get
            {
                if (_scheduleAppointmentCommand == null)
                {
                    _scheduleAppointmentCommand = new RelayCommand(
                        param => _windowFactory.CreateNewWindow(new ScheduleAppointmentWindowViewModel((CaseViewModel)param), new ScheduleAppointmentWindow()), param => ScheduleAppointmentCommandCanExectute()
                    );
                }
                return _scheduleAppointmentCommand;
            }
        }

        public ICommand CloseCaseCommand
        {
            get
            {
                if (_closeCaseCommand == null)
                {
                    _closeCaseCommand = new RelayCommand(
                        param => CloseCase((CaseViewModel)param), param => CloseCaseCanExecute((CaseViewModel)param)
                    );
                }
                return _closeCaseCommand;
            }
        }

        public ICommand RemoveCaseCommand
        {
            get
            {
                if (_removeCaseCommand == null)
                {
                    _removeCaseCommand = new RelayCommand(
                        param => RemoveCase((CaseViewModel) param)
                    );
                }
                return _removeCaseCommand;
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
                        param => ShowAll()
                    );
                }
                return _showAllCommand;
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
            Cases = _viewModel.AllCases;
            CasesForDisplay = Cases;
        }

        public void CloseCase(CaseViewModel caseVM)
        {
            //try
            //{
                this._receptionist.closePatientCase(caseVM.CaseObj, DateTime.Now);
                caseVM.EndDate = DateTime.Now;
            //}
            //catch (MySql.Data.MySqlClient.MySqlException)
            //{
               // FilterMessage = "Problem with SQL query";
            //}
        }

        public bool CloseCaseCanExecute(CaseViewModel caseVM)
        {
            try{
                if (caseVM.EndDate == null)
                {
                return true;
                }
            }
            catch (NullReferenceException ex)
            {
            
            }

            return false;
            
        }

        public void RemoveCase(CaseViewModel caseVM)
        {
            try
            {
                _receptionist.removeCase(caseVM.CaseObj);
                _cases.Remove(caseVM);
                this.refreshCasesForDisplay();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                FilterMessage = "Problem with SQL query";
            }
        }

        
        public void refreshCasesForDisplay()
        {
            CasesForDisplay = Cases;
        }


        public void FilterByLastName()
        {
            var result = _cases.Where(x => x.PatientSurname.ToLower().Contains(_filterString)).ToList();
            CasesForDisplay = new ObservableCollection<CaseViewModel>(result);
            FilterMessage = String.Format("Filtered by Last Name: {0}", FilterString);
            FilterString = "";
            
        }

        public void ShowAll()
        {
            CasesForDisplay = Cases;
            FilterMessage = "";
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

        public Boolean ScheduleAppointmentCommandCanExectute()
        {
            return true;
        }

    }
}
