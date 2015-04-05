using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Cases;
using Hospital.DataAccess.Util.ListCreators;

namespace Hospital.DataAccess.Repositories
{
    public class AppointmentsRepository : BaseRepository
    {
        private List<Appointment> _appointments;
        readonly AppointmentsListCreator _listCreator;

        public AppointmentsRepository()
        {
            if (_appointments == null)
            {
                _appointments = new List<Appointment>();
            }
            _listCreator = new AppointmentsListCreator();
            
        }

        public List<Appointment> GetAppointments(String query)
        {
            _appointments = _listCreator.createListOfAppointments(query);
            return _appointments;
        }
    }
}
