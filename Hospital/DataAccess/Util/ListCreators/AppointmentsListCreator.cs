using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Util;
using Hospital.Model.Cases;
using Hospital.DataAccess.Util.DatabaseModel;
using System.Data;


namespace Hospital.DataAccess.Util.ListCreators
{
    public class AppointmentsListCreator
    {
        private Database _database;

        public AppointmentsListCreator()
        {
            this._database = new Database();
        }

        public List<Appointment> createListOfAppointments(String query)
        {
            List<Appointment> appointments = new List<Appointment>();

            List<String> columnNames = DatabaseModel.ColumnNames.getAppointmentsColumnNames();
            String[,] results = _database.selectQuery(query, columnNames);

            DataTable table = CollectionsConverter.convertArrayToDataTable(results, columnNames);

            if (table.Rows.Count > 0)
            {
                appointments = (from p in table.AsEnumerable()
                                select new Appointment(int.Parse(p.Field<String>("patientID")), int.Parse(p.Field<String>("doctorID")), int.Parse(p.Field<String>("roomNumber")), MySqlDatesParser.parseDate(p.Field<String>("date")), p.Field<String>("reason"), int.Parse(p.Field<String>("caseID")))
                                {
                                    
                                }
                                    ).ToList();
            }

            return appointments;
        }
    }
}
