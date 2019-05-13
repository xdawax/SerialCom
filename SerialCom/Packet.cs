namespace SerialCom
{
    public class Packet
    {
        public enum Sensor_t
        {   // 1 byte if < 256 sensors
            REED,                   // the data can be read from the reed_data enum
            TEMP                    // the data is read as centidegrees celcius i.e. 3275 == 32.75 deg C
        };

        private const uint ACK = 0xFFFFFFFF;
        private const uint BUF_SIZE = 7;
        public const int BUF_ADDRESS = 0;
        public const int BUF_TYPE = 1;
        public const int BUF_DATA0 = 2;
        public const int BUF_DATA1 = 3;
        public const int BUF_DATA2 = 4;
        public const int BUF_DATA3 = 5;
        public const int BUF_SEQUENCE = 6;
        public byte Address { get; set; }
        public Sensor_t Type { get; set; }
        public uint Data { get; set; }
        public byte Sequence { get; set; }


        public string  Contents
        {
            get
            {
                return $"{ Address.ToString() } { Type.ToString() } { Data.ToString() } { Sequence.ToString() }";
            }
        }

        public void ToACK()
        {
            this.Data = ACK;
        }

        public byte[] PacketToBuf()
        {
            byte[] buf = new byte[BUF_SIZE];
            buf[BUF_ADDRESS] = this.Address;
            buf[BUF_TYPE] = (byte)this.Type;
            buf[BUF_DATA0] = (byte)(this.Data >> (0 * 8));
            buf[BUF_DATA1] = (byte)(this.Data >> (1 * 8));
            buf[BUF_DATA2] = (byte)(this.Data >> (2 * 8));
            buf[BUF_DATA3] = (byte)(this.Data >> (3 * 8));
            buf[BUF_SEQUENCE] = this.Sequence;

            return buf;

        }
    }
}
