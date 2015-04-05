using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People.Personel;
using Hospital.DataAccess.Util.ListCreators;

namespace Hospital.DataAccess.Repositories
{
    public class DoctorsRepository : BaseRepository
    {
        private List<Doctor> _doctors;
        readonly DoctorsListCreator _listCreator;

        public DoctorsRepository()
        {
            if (_doctors == null)
            {
                _doctors = new List<Doctor>();
            }
            _listCreator = new DoctorsListCreator();

        }

        public List<Doctor> GetDoctors(String query)
        {
            _doctors = _listCreator.createListOfDoctors(query);
            return _doctors;
        }
    }
}
