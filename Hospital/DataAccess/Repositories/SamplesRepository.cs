using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Laboratory;
using Hospital.DataAccess.Repositories;
using Hospital.DataAccess.Util.ListCreators;

namespace Hospital.DataAccess.Repositories
{
    public class SamplesRepository : BaseRepository
    {
        private List<Sample> _samples;
        readonly SamplesListCreator _listCreator;

        public SamplesRepository()
        {
            if (_samples == null)
            {
                _samples = new List<Sample>();
            }
            _listCreator = new SamplesListCreator();
            
        }

        public List<Sample> GetSamples(String query)
        {
            _samples = _listCreator.createListOfSamples(query);
            return _samples;
        }
    }
}
