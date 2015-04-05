using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People.Patients;
using Hospital.Model.Cases;
using Hospital.Model.Infrastructure;

namespace Hospital.Model.People.Personel
{
    public class Surgeon : Doctor
    {
        public Surgeon(String name, String surname, String gender, DateTime dateOfBirth, int mobileNumber, String email, String speciality, int roomNumber)
            : base(name, surname, gender, dateOfBirth, mobileNumber, email, speciality, roomNumber) 
        { 
            
        }

        public void scheduleSurgery(Patient patient, DateTime date, Room room) { }
        public void rescheduleSurgery(Surgery surgery, DateTime date) { }
    }
}
