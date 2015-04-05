using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Infrastructure
{
    public class PatientRoom : Room
    {
        public int totalBeds { get; set; }
        public List<Bed> beds { get; set; }
    }
}
