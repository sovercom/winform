using project02.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;


namespace project02
{
    public class DBmanager
    {
        const String connectString = "Server=127.0.0.1;Database=gydb;Uid=gyuser;Pwd=4321";
        public static List<MachineCensor> SelectDB(string query)
        {
            List<MachineCensor> machineCensorList = new List<MachineCensor>();

            DataTable dataTable = new DataTable();
            MySqlConnection connection = new MySqlConnection(connectString);

            try
            {
                //MySqlConnection connection = new MySqlConnection(connectString);
                connection.Open();
                Console.WriteLine("DB연결이 성공하였습니다.");

            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine("DB접속이 실패했습니다.");
            }



            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            dataTable.Load(mySqlDataReader);

            foreach (DataRow row in dataTable.Rows)
            {
                machineCensorList.Add(new MachineCensor
                {
                    managerName = (string)row["managerName"],
                    machineName = (string)row["machineName"],
                    temperature = Convert.ToInt32(row["temperature"]),
                    power = Convert.ToInt32(row["power"]),
                    runtime = Convert.ToInt32(row["runtime"])
                });

            }
            mySqlDataReader.Close();
            connection.Close();

            return machineCensorList;

        }





    }
}



