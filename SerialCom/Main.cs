using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace SerialCom
{
    public partial class Main : Form
    {

        
        private byte packetSize = 7;
        private string comPort = "UNDEFINED";

        public Main()
        {
            InitializeComponent();

            populateComPorts();

            buttonSend.Enabled = false;
            checkBoxIM.Enabled = false;
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
            if (!mySerialPort.IsOpen) return;
            byte received_byte = 0;
            byte index = 0;
            byte[] rxBuf = new byte[255];

            while (received_byte != Packet.END_COM)
            {
                received_byte = (byte)mySerialPort.ReadByte();
                rxBuf[index] = received_byte;
                index++;
            }

            handleData(rxBuf);
            
            this.Invoke(new EventHandler(displayText));
        }

        private void handleData(byte[] buf)
        {
            Packet packet = new Packet();

            packet.Address = buf[Packet.BUF_ADDRESS];
            packet.Type = (Packet.Sensor_t)buf[Packet.BUF_TYPE];
            packet.Data = BitConverter.ToUInt32(buf, Packet.BUF_DATA0);
            packet.Sequence = buf[Packet.BUF_SEQUENCE];
            SensorDataAccess.SaveData(packet);
            transmitACK(packet);
        }

        private void transmitACK(Packet packet)
        {
            if (!mySerialPort.IsOpen) return;
            packet.ToACK();
            byte[] buf = packet.PacketAsBuf();
            Int32 size = buf.Length;

            mySerialPort.Write(buf, 0 ,size);
        }

        public void displayPacketContent(Packet packet)
        {
            richTextBoxRX.AppendText(packet.Contents);
            richTextBoxRX.AppendText("\n");
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
            List<Packet> packetList = new List<Packet>();
            packetList = SensorDataAccess.ListAll();

            if (packetList.Count > 0)
            {
                richTextBoxRX.AppendText("The database contains the following packets: \n");

                foreach (Packet packet in packetList)
                {
                    displayPacketContent(packet);
                }
            }
            else
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
            if (listBoxComPorts.SelectedItem != null)
            {
                comPort = listBoxComPorts.SelectedItem.ToString();
            }
        }

        private void buttonSelectCom_Click(object sender, EventArgs e)
        {
            string port = comPort;
            if (comPort == "UNDEFINED")
            {
                MessageBox.Show("No com port selected!");
            }
            else
            {
                if (mySerialPort.IsOpen)
                {
                    mySerialPort.Close();
                }
                mySerialPort.PortName = comPort;
                mySerialPort.Open();
                buttonSend.Enabled = true;
                checkBoxIM.Enabled = true;
            }
        }

        private void buttonDisplaySensors_Click(object sender, EventArgs e)
        {
            this.Hide();
            SensorData sensData = new SensorData(this);
            sensData.Show();
        }

        public void closeSerialPort()
        {
            mySerialPort.Close();
        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.Address = 9;
            packet.Type = Packet.Sensor_t.REED;
            packet.Sequence = 123;
            packet.ToACK();

            transmitACK(packet);
        }
    }

}
