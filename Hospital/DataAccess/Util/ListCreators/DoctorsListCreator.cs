using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.People.Personel;
using System.Data;


namespace Hospital.DataAccess.Util.ListCreators
{
    public class DoctorsListCreator
    {
            private Database _database;

            public DoctorsListCreator()
            {
                this._database = new Database();
            }

            public List<Doctor> createListOfDoctors(String query)
            {
                List<Doctor> doctors = new List<Doctor>();

                List<String> columnNames = DatabaseModel.ColumnNames.getDoctorsColumnNames();
                String[,] results = _database.selectQuery(query, columnNames);

                DataTable table = CollectionsConverter.convertArrayToDataTable(results, columnNames);

                if (table.Rows.Count > 0)
                {
                    doctors = (from p in table.AsEnumerable()
                               select new Doctor(p.Field<String>("name"), p.Field<String>("surname"), p.Field<String>("gender"), MySqlDatesParser.parseDate(p.Field<String>("dateOfBirth")), int.Parse(p.Field<String>("mobileNumber")), p.Field<String>("email"), p.Field<String>("specialty"), int.Parse(p.Field<String>("roomNumber")))
                                    {
                                        doctorID = int.Parse(p.Field<String>("doctorID")),
                                        employeeID = int.Parse(p.Field<String>("employeeID"))
                                    }
                                        ).ToList();
                }

                return doctors;
            }
      
    }
}
