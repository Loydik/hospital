using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel.Helpers;
using Hospital.ViewModel.General.Patients;
using Hospital.ViewModel.General.Samples;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace Hospital.ViewModel.General.Samples
{
    public class SamplesWindowViewModel : ObservableObject, IPageViewModel 
    {
        private PatientViewModel _patient;
        private SamplesViewModel _samplesVM;
        private SamplesViewModel _viewModel;
        private ObservableCollection<SampleViewModel> _allSamples;
        private ObservableCollection<SampleViewModel> _patientSamples;
        private ICommand _addNewSampleCommand;
        private IWindowFactory _windowFactory;
        
        public SamplesWindowViewModel()
        {
            this._samplesVM = new SamplesViewModel();
            this._allSamples = _samplesVM.AllSamples;
            this._windowFactory = new ProductionWindowFactory();
        }

        public SamplesWindowViewModel(PatientViewModel patient)
        {
            this._patient = patient;
            this._samplesVM = new SamplesViewModel();
            this._allSamples = _samplesVM.AllSamples;
            this._patientSamples = this.getSamplesByPatientId(patient.PatientID);
        }

        public string Name
        {
            get { return "Samples"; }
        }

        public ObservableCollection<SampleViewModel> Samples
        {
            get
            { return _allSamples; }
            set
            {
                this._allSamples = value;
                OnPropertyChanged("Samples");
            }
        }

        public ObservableCollection<SampleViewModel> PatientSamples
        {
            get
            { return _patientSamples; }
            set
            {
                this._patientSamples = value;
                OnPropertyChanged("PatientSamples");
            }
        }

        public ObservableCollection<SampleViewModel> getSamplesByPatientId(int id)
        {
            IEnumerable<SampleViewModel> result = _allSamples.Where(SampleViewModel => SampleViewModel.PatientID == id).Select(SampleViewModel => SampleViewModel);
            return new ObservableCollection<SampleViewModel>(result);
        }

    }
}
