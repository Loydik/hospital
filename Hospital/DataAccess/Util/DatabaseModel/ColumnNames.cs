using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.Util.DatabaseModel
{
    public class ColumnNames
    {
        private static List<String> patients = new List<String> { "patientID", "name", "surname", "gender", "dateOfBirth", "mobileNumber", "email", "medicalCardID", "dateOfRegistration", "underTreatment" };

        private static List<String> cases = new List<String> {"case_id", "patientID", "start_date", "end_date", "description"};

        private static List<String> appointments = new List<String> { "appointmentID", "patientID", "doctorID", "roomNumber", "date", "reason", "caseID"};

        private static List<String> doctors = new List<String> {"doctorID", "employeeID", "name", "surname", "employmentDate", "gender", "dateOfBirth", "mobileNumber", "email", "department_id", "specialty", "roomNumber"};

        private static List<String> samples = new List<String> { "sample_id", "patient_id", "doctor_id", "creation_date", "tested", "tested_by_lab_worker_id", "result"};

        public static List<String> getPatientColumnNames()
        {
            return patients;
        }

        public static List<String> getCasesColumnNames()
        {
            return cases;
        }

        public static List<String> getAppointmentsColumnNames()
        {
            return appointments;
        }

        public static List<String> getDoctorsColumnNames()
        {
            return doctors;
        }

        public static List<String> getSamplesColumnNames()
        {
            return samples;
        }
    }
}
