using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.People
{
    public class Person
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int mobileNumber { get; set; }
        public String email { get; set; }

        public Person()
        { 
        
        }

        public Person(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email)
        {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.mobileNumber = mobileNumber;
            this.email = email;
        }
    }
}
