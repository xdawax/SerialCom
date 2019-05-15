using System;

namespace SerialCom
{
    public class Packet
    {
        public enum Sensor_t
        {   // 1 byte if < 256 sensors
            REED,                   // the data can be read from the reed_data enum
            TEMP                    // the data is read as centidegrees celcius i.e. 3275 == 32.75 deg C
        };

        
        private const uint ACK = 0xFEFEFEFE;
        public const byte END_COM = 0xFF;
        private const uint BUF_SIZE = 9;
        public const int BUF_ADDRESS = 0;
        public const int BUF_TYPE = 1;
        public const int BUF_DATA0 = 2;
        public const int BUF_DATA1 = 3;
        public const int BUF_DATA2 = 4;
        public const int BUF_DATA3 = 5;
        public const int BUF_SEQUENCE = 6;
        public const int BUF_CHECKSUM = 7;
        public const int BUF_END_COM = 8;
        public byte Address { get; set; }
        public Sensor_t Type { get; set; }
        public uint Data { get; set; }
        public byte Sequence { get; set; }
        public byte CheckSum { get; set; }
        public string CreationDate { get; set; }

        public Packet()
        {
            this.CreationDate = DateTime.Now.ToString();
        }

        public Packet(byte[] buf)
        {
            this.CreationDate = DateTime.Now.ToString();
            this.Address = buf[Packet.BUF_ADDRESS];
            this.Type = (Packet.Sensor_t)buf[Packet.BUF_TYPE];
            this.Data = BitConverter.ToUInt32(buf, Packet.BUF_DATA0);
            this.Sequence = buf[Packet.BUF_SEQUENCE];
            this.CheckSum = buf[Packet.BUF_CHECKSUM];
        }
        public string  Contents
        {
            get
            {
                return $"{ Address.ToString() } { Type.ToString() } " +
                    $"{ Data.ToString() } { Sequence.ToString() } { CheckSum.ToString() } { CreationDate.ToString() }";
            }
        }

        public void ToACK()
        {
            this.Data = ACK;
        }

        public void ToNACK()
        {
            this.Address = 0;
            this.CheckSum = 0;
            this.Data = 0;
            this.Sequence = 0;
            this.Type = 0;
            this.CheckSum = 0;
        }

        public byte[] PacketAsBuf()
        {
            byte[] buf = new byte[BUF_SIZE];
            buf[BUF_ADDRESS] = this.Address;
            buf[BUF_TYPE] = (byte)this.Type;
            buf[BUF_DATA0] = (byte)(this.Data >> (0 * 8));
            buf[BUF_DATA1] = (byte)(this.Data >> (1 * 8));
            buf[BUF_DATA2] = (byte)(this.Data >> (2 * 8));
            buf[BUF_DATA3] = (byte)(this.Data >> (3 * 8));
            buf[BUF_SEQUENCE] = this.Sequence;
            buf[BUF_CHECKSUM] = this.CheckSum;
            buf[BUF_END_COM] = END_COM;
            return buf;

        }

        public byte checkSum()
        {
            byte[] buf = this.PacketAsBuf();
            int size = buf.Length - 2;
            uint checkSum = 0;

            for (int i = 0; i < size; i++)
            {
                checkSum += buf[i];
            }

            return (byte)checkSum;
        }

        public bool correctCheckSum()
        {
            return (this.CheckSum == this.checkSum());
        }

        public void setCheckSum()
        {
            this.CheckSum = this.checkSum();
        }

    }
}
