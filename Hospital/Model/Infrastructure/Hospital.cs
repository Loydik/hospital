using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Infrastructure
{
    class Hospital
    {
        public String name {get; set;}
        public String address { get; set; }
        public int telephone { get; set; }
        public List<Department> departments { get; set; }

    }
}
