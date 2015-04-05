using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People.Patients;
using Hospital.DataAccess.Util.ListCreators;

namespace Hospital.DataAccess.Repositories
{
    public class PatientRepository : BaseRepository
    {
        readonly List<Patient> _patients;
        readonly PatientListCreator _listCreator;

        public PatientRepository()
        {
            if (_patients == null)
            {
                _patients = new List<Patient>();
            }
            _listCreator = new PatientListCreator();
            _patients = _listCreator.createListofPatientObjects();
        }

        public List<Patient> GetPatients()
        {
            return _patients;
        }
    }
}
