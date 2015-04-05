using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People.Patients;
using Hospital.DataAccess.Util.DatabaseModel;
using System.Data;
using System.Globalization;
using Hospital.DataAccess.Util;

namespace Hospital.DataAccess.Util.ListCreators
{
    public class PatientListCreator
    {
        private Database _database;

        public PatientListCreator()
        {
            this._database = new Database();
        }

        public List<Patient> createListofPatientObjects()
        {
            List<Patient> patients = new List<Patient>();

            List<String> columnNames = DatabaseModel.ColumnNames.getPatientColumnNames();
            String query = "SELECT * FROM Patients";
            String[,] results = _database.selectQuery(query, columnNames);

            DataTable table = CollectionsConverter.convertArrayToDataTable(results, columnNames);

            if (table.Rows.Count > 0)
            {
                patients = (from p in table.AsEnumerable()
                            select new Patient(p.Field<String>("name"), p.Field<String>("surname"), p.Field<String>("gender"), MySqlDatesParser.parseDate(p.Field<String>("dateOfBirth")), int.Parse(p.Field<String>("mobileNumber")), p.Field<String>("email"), MySqlDatesParser.parseDate(p.Field<String>("dateOfRegistration")), int.Parse(p.Field<String>("patientID")), int.Parse(p.Field<String>("medicalCardID")), Convert.ToBoolean(int.Parse(p.Field<String>("underTreatment"))))
                                {
           
                                }

                                    ).ToList();
            }

            return patients;
        }
    }
}
