namespace SerialCom
{
    public class Packet
    {
        public enum Sensor_t
        {   // 1 byte if < 256 sensors
            REED,                   // the data can be read from the reed_data enum
            TEMP                    // the data is read as centidegrees celcius i.e. 3275 == 32.75 deg C
        };

        public byte Address { get; set; }
        public Sensor_t Type { get; set; }
        public int Data { get; set; }


        public string  Contents
        {
            get
            {
                return $"{ Address.ToString() } { Type.ToString() } { Data.ToString() }";
            }
        }
    }
}
