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
        private SerialPort _serialPort;

        public SerialCom(Int32 baudRate, int parity, int stopBits)
        {
            this._serialPort.BaudRate = baudRate;
            this._serialPort.Parity = parity;
            this._serialPort.StopBits = stopBits;
        }

    }
}
