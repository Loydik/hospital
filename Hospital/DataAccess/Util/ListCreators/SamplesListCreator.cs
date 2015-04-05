using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Laboratory;
using System.Data;

namespace Hospital.DataAccess.Util.ListCreators
{
    public class SamplesListCreator
    {
        private Database _database;

        public SamplesListCreator()
        {
            this._database = new Database();
        }

        public List<Sample> createListOfSamples(String query)
        {
            List<Sample> samples = new List<Sample>();

            List<String> columnNames = DatabaseModel.ColumnNames.getSamplesColumnNames();
            String[,] results = _database.selectQuery(query, columnNames);

            DataTable table = CollectionsConverter.convertArrayToDataTable(results, columnNames);

            if (table.Rows.Count > 0)
            {
                samples = (from p in table.AsEnumerable()
                           select new Sample(int.Parse(p.Field<String>("patient_id")), int.Parse(p.Field<String>("doctor_id")), MySqlDatesParser.parseDate(p.Field<String>("creation_date")), p.Field<String>("result"))
                                {
                                    sampleID = int.Parse(p.Field<String>("sample_id")),
                                    tested = Convert.ToBoolean(Convert.ToInt32(p.Field<String>("tested")))
                                }
                                    ).ToList();
            }

            return samples;
        }
    }
}
