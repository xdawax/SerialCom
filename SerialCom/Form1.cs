using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SerialCom
{



    public partial class Form1 : Form
    {
        public enum Sensor_t
        {   // 1 byte if < 256 sensors
            REED,                   // the data can be read from the reed_data enum
            TEMP                    // the data is read as centidegrees celcius i.e. 3275 == 32.75 deg C
        };
        public struct Packet_t
        {
            public byte address;
            public Sensor_t type;
            public uint data;
            //time_stamp_t  time_stamp;		// TODO
        };

        private static int BUF_ADDRESS = 0;
        private static int BUF_TYPE = 1;
        private static int BUF_DATA0 = 2;
        private static int BUF_DATA1 = 3;
        private static int BUF_DATA2 = 4;
        private static int BUF_DATA3 = 5;
        private static int BUF_STAMP0 = 6;
        private static int BUF_STAMP1 = 7;
        private static int BUF_STAMP2 = 8;
        private static int BUF_STAMP3 = 9;
        private static int BUF_STAMP4 = 10;

        private Queue packetQueue = new Queue();
        private byte packetSize = 6;
        private string comPort = "UNDEFINED";

        public Form1()
        {
            InitializeComponent();

            populateComPorts();

            if (!mySerialPort.IsOpen)
            {
                mySerialPort.Open();
                richTextBoxRX.Text = "Serial port is open :)";
            } 
            else
            {
                richTextBoxRX.Text = "Serial port is busy :(";
            }
        }

        private void populateComPorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();

            // Display each port name to the console.
            foreach (string port in ports)
            {
                listBoxComPorts.Items.Add(port);
            }
        }

        private void mySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte received = 0;
            byte[] rxBuf = new byte[255];

            for (int i = 0; i < packetSize; i++) { 
                received = (byte)mySerialPort.ReadByte();
                rxBuf[i] = received;
            }

            handleData(rxBuf);
            this.Invoke(new EventHandler(displayText));
        }

        private void handleData(byte[] buf)
        {
            Packet_t packet;

            packet.address = buf[BUF_ADDRESS];
            packet.type = (Sensor_t)buf[BUF_TYPE];

            packet.data = (uint)BitConverter.ToInt32(buf, BUF_DATA0);

            packetQueue.Enqueue(packet);
        }

        private void displayPacketContent(Packet_t packet)
        {
            string sens;

            switch (packet.type)
            {
                case Sensor_t.REED:
                    sens = "REED";
                    break;
                case Sensor_t.TEMP:
                    sens = "TEMP";
                    break;
                default:
                    sens = "UNDEFINED";
                    break;
            }

            richTextBoxRX.AppendText("Packet contents: \n");
            richTextBoxRX.AppendText("Address: " + (packet.address).ToString() + "\n");
            richTextBoxRX.AppendText("Type: " + sens + "\n");
            richTextBoxRX.AppendText("Data: " + (packet.data).ToString() + "\n");
        }

        private string bufToString(byte[] buf)
        {
            string bufString = string.Empty;

            foreach (byte b in buf)
            {
                bufString += (Char)b;
            }

            return bufString;
        }

        private void displayText(object o, EventArgs e)
        {
            // visa data för samtliga element i kön
            richTextBoxRX.Clear();

            if (packetQueue.Count > 0)
            {
                richTextBoxRX.AppendText("The queue contains the following packets: \n");

                foreach (Packet_t packet in packetQueue) {
                    displayPacketContent(packet);
                }
            } else
            {
                richTextBoxRX.AppendText("There is nothing in the queue!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            mySerialPort.Write(richTextBoxTX.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxTX.Clear();
            richTextBoxRX.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mySerialPort.Close();
        }

        private void richTextBoxTX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mySerialPort.IsOpen && checkBoxIM.Checked)
            {
                char[] ch = new char[1];
                ch[0] = e.KeyChar;
                mySerialPort.Write(ch, 0, 1);
            }
        }

        private void listBoxComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comPort == "UNDEFINED")
            {
                System.Windows.Forms.MessageBox.Show("No com port selected!");
            }
        }
    }
}
