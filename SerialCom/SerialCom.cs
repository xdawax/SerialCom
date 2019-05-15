using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SerialCom
{
    class SerialCom
    {
        private SerialPort _serialPort = new SerialPort();

        public SerialCom(string portName, Int32 baudRate, Parity parity, StopBits stopBits)
        {
            this._serialPort.PortName = portName;
            this._serialPort.BaudRate = baudRate;
            this._serialPort.Parity = parity;
            this._serialPort.StopBits = stopBits;
            this._serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            
        }

        public void closePort()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        public void openPort()
        {
            if (!_serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Open();
                }
                catch (Exception)
                {
                    
                }
                
            }
        }

        public string getPortName()
        {
            return this._serialPort.PortName;
        }

        public bool isOpen()
        {
            return _serialPort.IsOpen;
        }

        private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (!_serialPort.IsOpen) return;
            byte received_byte = 0;
            byte index = 0;
            byte[] rxBuf = new byte[255];

            while (received_byte != Packet.END_COM)
            {
                received_byte = (byte)_serialPort.ReadByte();
                rxBuf[index] = received_byte;
                index++;
            }

            handleData(rxBuf);
        }

        private void handleData(byte[] buf)
        {
            Packet packet = new Packet(buf);

            // if the checksum is correct store the packet in the db and send ack
            if (packet.correctCheckSum())
            {
                SensorDataAccess.SaveData(packet);
                transmitACK(packet);
            }
            else
            {
                transmitNACK(packet);
            }
        }

        private void transmitNACK(Packet packet)
        {
            if (!_serialPort.IsOpen) return;
            packet.ToNACK();

            byte[] buf = packet.PacketAsBuf();
            Int32 size = buf.Length;

            _serialPort.Write(buf, 0, size);
        }

        private void transmitACK(Packet packet)
        {
            if (!_serialPort.IsOpen) return;
            packet.ToACK();
            byte[] buf = packet.PacketAsBuf();
            Int32 size = buf.Length;

            _serialPort.Write(buf, 0, size);
        }

    }
}
