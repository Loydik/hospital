using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Repositories;
using System.Collections.ObjectModel;
using Hospital.ViewModel.Helpers;
using Hospital.Model.Laboratory;

namespace Hospital.ViewModel.General.Samples
{
    public class SamplesViewModel : ObservableObject
    {
        private SamplesRepository _repository;
        String _allSamplesQuery = "SELECT * FROM Samples";

        private ObservableCollection<SampleViewModel> _allSamples;

        public ObservableCollection<SampleViewModel> AllSamples
        {
            get
            { return _allSamples; }
            set
            {
                _allSamples = value;
                OnPropertyChanged("AllSamples");
            }
        }

        public SamplesViewModel()
        {
            this.init();
        }

        public void createObservableSamplesFromList(List<Sample> samples)
        {
            if (samples != null)
            {
                foreach (Sample obj in samples)
                {
                    AllSamples.Add(new SampleViewModel(obj));
                }
            }
        }

        private void init()
        {
            _repository = new SamplesRepository();
            _allSamples = new ObservableCollection<SampleViewModel>();

            if (_repository == null)
            {
                throw new ArgumentNullException("Problem with fetching Data From Database");
            }

            this.createObservableSamplesFromList(_repository.GetSamples(_allSamplesQuery));

        }

        public void refresh()
        {
            this.init();
            RaisePropertyChanged("AllSamples");
        }

    }
}
