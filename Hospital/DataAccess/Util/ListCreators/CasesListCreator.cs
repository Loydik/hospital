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
    public class CasesListCreator
    {
        private Database _database;

        public CasesListCreator()
        {
            this._database = new Database();
        }

        public List<Case> createListOfCasesObjects(String query)
        {
            List<Case> cases = new List<Case>();

            List<String> columnNames = DatabaseModel.ColumnNames.getCasesColumnNames();
            String[,] results = _database.selectQuery(query, columnNames);

            DataTable table = CollectionsConverter.convertArrayToDataTable(results, columnNames);

            if (table.Rows.Count > 0)
            {
                cases = (from p in table.AsEnumerable()
                         select new Case(int.Parse(p.Field<String>("patientID")), MySqlDatesParser.parseDate(p.Field<String>("start_date")), p.Field<String>("description"))
                                {
                                    caseID = int.Parse(p.Field<String>("case_id")),
                                    endDate = MySqlDatesParser.parseNullableDate(p.Field<String>("end_date"))
                                }
                                    ).ToList();
            }

            return cases;
        }
    }
}
