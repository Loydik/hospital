using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Laboratory;
using Hospital.ViewModel.Helpers;

namespace Hospital.ViewModel.General.Samples
{
    public class SampleViewModel : ObservableObject
    {
        private Sample sampleObj;

        public Sample SampleObj
        {
            get
            { return sampleObj; }
            set
            {
                sampleObj = value;
                OnPropertyChanged("SampleObj");
            }
        }

        public int SampleID
        {
            get
            { return sampleObj.sampleID; }
            set
            {
                sampleObj.sampleID = value;
                OnPropertyChanged("SampleID");
            }
        }

        public int PatientID
        {
            get
            { return sampleObj.patientID; }
            set
            {
                sampleObj.patientID = value;
                OnPropertyChanged("PatientID");
            }
        }

         public int DoctorID
        {
            get
            { return sampleObj.doctorID; }
            set
            {
                sampleObj.doctorID = value;
                OnPropertyChanged("DoctorID");
            }
        }

        public DateTime CreationDate
        {
            get
            { return sampleObj.creationDate; }
            set
            {
                sampleObj.creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }

        public Boolean Tested
        {
            get
            { return sampleObj.tested; }
            set
            {
                sampleObj.tested = value;
                OnPropertyChanged("Tested");
            }
        }

        public String Result
        {
            get
            { return sampleObj.result; }
            set
            {
                sampleObj.result = value;
                OnPropertyChanged("Result");
            }
        }

        public SampleViewModel(Sample obj) 
        {
             this.sampleObj= new Sample();
             SampleID = obj.sampleID;
             PatientID = obj.patientID;
             DoctorID = obj.doctorID;
             CreationDate = obj.creationDate;
             Tested = obj.tested;
             Result = obj.result;
        }

    }
}
