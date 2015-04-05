using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.Util.ListCreators
{
    public class AppointmentTimesListCreator
    {
            private Database _database;

            public AppointmentTimesListCreator()
            {
                this._database = new Database();
            }

            public List<String> createListOfAppointmentTimes(String query)
            {
                List<String> appointmentTimes = new List<String>();

                List<String> columnNames = new List<String>() {"time"};
                String[,] results = _database.selectQuery(query, columnNames);

                for (int i = 0; i < results.GetLength(0); i++)
                {
                    appointmentTimes.Add(results[i,0]);
                }

               return appointmentTimes;
            }
        }
}
