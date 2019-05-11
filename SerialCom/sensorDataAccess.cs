using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SerialCom
{
    public class SensorDataAccess
    {
        public static List<Packet> ListAll()
        {
            // failsafe, closes the db if crashed or we reach the end of brackets
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Packet>("select * from Sensor", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Packet> ListSensorData(int sensorAddress)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Packet>("select * from Sensor where Address = " + sensorAddress, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Packet> ListSensorTypeData(int sensorType)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Packet>("select * from Sensor where Type = " + sensorType, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<byte> ListSensorAddresses()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<byte>("SELECT DISTINCT Address FROM Sensor;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Packet> ListByAddress(byte address)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Packet>("SELECT * FROM Sensor WHERE Address = " + address + ";", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveData(Packet packet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Sensor (Address, Data, Type) values (@Address, @Data, @Type)", packet);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
