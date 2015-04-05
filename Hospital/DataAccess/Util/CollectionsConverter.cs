using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital.DataAccess.Util
{
    public class CollectionsConverter
    {
        public static String[,] convertListToArray(List<String> list, int numberOfColumns) 
        {
            int numberOfRows = (int)list.Count/numberOfColumns;
            String[,] result = new String[numberOfRows, numberOfColumns];
            int x = 0;

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                { 
                    result[i,j] = list[x];
                    x++;
                }
            }

            return result;
        }

        public static DataTable convertArrayToDataTable(String[,] array, List<String> columnNames)
        {
            DataTable table = new DataTable();
            int rows = array.GetLength(0);            

            foreach (String columnName in columnNames)
            {
                table.Columns.Add(columnName);
            }


            for (int outerIndex = 0; outerIndex < rows; outerIndex++)
            {
                DataRow newRow = table.NewRow();
                for (int innerIndex = 0; innerIndex < columnNames.Count; innerIndex++)
                {
                    newRow[innerIndex] = array[outerIndex, innerIndex];
                }
                table.Rows.Add(newRow);
            }

            return table;
        }
    }
}
