using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Util;

namespace Hospital.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected Database db = new Database();
    }
}
