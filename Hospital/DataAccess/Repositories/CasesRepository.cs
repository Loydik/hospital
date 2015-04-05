using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Cases;
using Hospital.DataAccess.Util.ListCreators;

namespace Hospital.DataAccess.Repositories
{
    public class CasesRepository : BaseRepository
    {
        private List<Case> _cases;
        readonly CasesListCreator _listCreator;

        public CasesRepository()
        {
            if (_cases == null)
            {
                _cases = new List<Case>();
            }
            _listCreator = new CasesListCreator();
            
        }

        public List<Case> GetCases(String query)
        {
            _cases = _listCreator.createListOfCasesObjects(query);
            return _cases;
        }
    }
}
