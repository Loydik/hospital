using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People.Personel;

namespace Hospital.Model.Infrastructure
{
    class Department
    {
        public String name { get; set; }
        public List<Employee> employees {get; set;}
        public List<Room> rooms {get; set;}
    }
}
