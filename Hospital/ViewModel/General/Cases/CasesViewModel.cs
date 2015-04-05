using System;
using Hospital.DataAccess.Repositories;
using Hospital.Model.Cases;
using System.Collections.ObjectModel;
using Hospital.ViewModel.Helpers;
using System.Collections.Generic;

namespace Hospital.ViewModel.General.Cases
{
    public class CasesViewModel : ObservableObject
    {
        private CasesRepository _casesRepository;
        String _allCasesQuery = "SELECT * FROM Cases";
        private ObservableCollection<CaseViewModel> _allCases;

        public ObservableCollection<CaseViewModel> AllCases
        {
            get
            { return _allCases; }
            set
            {
                _allCases = value;
                OnPropertyChanged("AllCases");
            }
        }

        public CasesViewModel()
        {
            this.init();
        }

        public void createObservableCasesFromList(List<Case> cases)
        {
            if (cases != null)
            {
                foreach (Case caseObj in cases)
                {
                    _allCases.Add(new CaseViewModel(caseObj));
                }
            }
        }

        private void init()
        {
            _casesRepository = new CasesRepository();
            _allCases = new ObservableCollection<CaseViewModel>();

            if (_casesRepository == null)
            {
                throw new ArgumentNullException("Problem with fetching Data From Database");
            }

            this.createObservableCasesFromList(_casesRepository.GetCases(_allCasesQuery));
        }

        public void refresh()
        {
            this.init();
            RaisePropertyChanged("AllCases");
        }


    }
}
