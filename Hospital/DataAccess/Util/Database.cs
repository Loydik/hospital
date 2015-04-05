using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hospital.DataAccess.Util
{
    public class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Database()
        {
            Initialize();
        }

        private void Initialize()
        {
           /* server = "sql3.freesqldatabase.com";
            database = "sql363680";
            uid = "sql363680";
            password = "qM4%vC6%";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";*/

            server = "localhost";
            database = "sql363680";
            uid="root";
            password = "hello48282";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

  
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public void executeQuery(String query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


        public String[,] selectQuery(String query, List<String> columnNames)
        {
            List<String> list = new List<String>();
            String[,] result = null;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
  
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                            for (int i = 0; i < columnNames.Count; i++)
                            {
                                list.Add(dataReader[columnNames[i]] + "");
                            }
                    }
                }

                dataReader.Close();

                this.CloseConnection();

                result = CollectionsConverter.convertListToArray(list, columnNames.Count);

                return result;
            }
            else
            {
                return result;
            }
        }

        public String selectSingleQuery(String query)
        {
            String result = "";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result = dataReader.GetString(0);
                    }
                }

                dataReader.Close();

                this.CloseConnection();

                return result;
            }

            return result;
        }

        public int Count(String query)
        {
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public DataTable getDataTableSelectQuery(String query, List<String> columnNames)
        {
            DataTable result = null;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                msda.Fill(result);

                this.CloseConnection();

                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
