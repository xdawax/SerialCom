using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCom
{
    public class sensorDataAccess
    {
        public static List<Packet> LoadAll()
        {
            // failsafe, closes the db if crashed or we reach the end of brackets
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Packet>("select * from Sensor", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveData(Packet packet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Sensor (Address, Data, Type) values(@Address, @Data, @Type", packet);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
