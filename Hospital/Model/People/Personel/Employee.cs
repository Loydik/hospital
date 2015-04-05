using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.Model.People.Personel
{
    public class Employee : Person
    {
        public int employeeID { get; set; }
        public DateTime employmentDate { get; set; }
        public int workTelephoneNumber { get; set; }

        public Employee()
        { }

        public Employee(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email) : base(name, surname, gender, dateOfBirth, mobileNumber, email) 
        { 
            
        }
    }
}
