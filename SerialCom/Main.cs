using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

namespace SerialCom
{
    public partial class Main : Form
    {
        private const int baudRate = 38400;
        private const Parity parity = Parity.None;
        private const StopBits stopBits = StopBits.One;

        private string comPort = "UNDEFINED";
        private List<SerialCom> connections = new List<SerialCom>();

        public Main()
        {
            InitializeComponent();
            InitConnections();
            OpenConnections();
            displayConnections();

            buttonSend.Enabled = false;
            checkBoxIM.Enabled = false;
        }

        private void InitConnections()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            
            // Display each port name to the console.
            foreach (string port in ports)
            {
                SerialCom con = new SerialCom(port, baudRate, parity, stopBits);
                connections.Add(con);
            }
        }

        private void OpenConnections()
        {
            foreach (SerialCom con in connections)
            {
                if (!con.isOpen())
                {
                    con.openPort();
                }
            }
        }

        private void nextConnection()
        {

        }

        private void displayConnections()
        {
            richTextBoxRX.Clear();
            richTextBoxRX.AppendText("Connected units:\n");
            foreach (SerialCom connection in connections)
            {
                if (connection.isOpen())
                {
                    richTextBoxRX.AppendText(connection.getPortName());
                    richTextBoxRX.AppendText("\n");
                }
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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {/*
            if (!serialPort1.IsOpen) return;
            byte received_byte = 0;
            byte index = 0;
            byte[] rxBuf = new byte[255];

            while (received_byte != Packet.END_COM)
            {
                received_byte = (byte)serialPort1.ReadByte();
                rxBuf[index] = received_byte;
                index++;
            }

            handleData(rxBuf);
            
            this.Invoke(new EventHandler(displayText));*/
        }

        private void handleData(byte[] buf)
        {/*
            Packet packet = new Packet();

            packet.Address = buf[Packet.BUF_ADDRESS];
            packet.Type = (Packet.Sensor_t)buf[Packet.BUF_TYPE];
            packet.Data = BitConverter.ToUInt32(buf, Packet.BUF_DATA0);
            packet.Sequence = buf[Packet.BUF_SEQUENCE];
            packet.CheckSum = buf[Packet.BUF_CHECKSUM];
            byte debug_sum = packet.checkSum();

            // if the checksum is correct store the packet in the db and send ack
            if (packet.checkSum() == packet.CheckSum)
            {
                SensorDataAccess.SaveData(packet);
                transmitACK(packet);
            } else
            {
                transmitNACK(packet);
            }*/
        }

        private void transmitNACK(Packet packet)
        {/*
            if (!serialPort1.IsOpen) return;
            packet.ToNACK();

            byte[] buf = packet.PacketAsBuf();
            Int32 size = buf.Length;

            serialPort1.Write(buf, 0, size);*/
        }

        private void transmitACK(Packet packet)
        {/*
            if (!serialPort1.IsOpen) return;
            packet.ToACK();
            byte[] buf = packet.PacketAsBuf();
            Int32 size = buf.Length;

            serialPort1.Write(buf, 0 ,size);*/
        }

        public void displayPacketContent(Packet packet)
        {
            richTextBoxRX.AppendText(packet.Contents);
            richTextBoxRX.AppendText("\n");
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
           // serialPort1.Write(richTextBoxTX.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxTX.Clear();
            richTextBoxRX.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //serialPort1.Close();
        }
        
        private void richTextBoxTX_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            if (serialPort1.IsOpen && checkBoxIM.Checked)
            {
                char[] ch = new char[1];
                ch[0] = e.KeyChar;
                serialPort1.Write(ch, 0, 1);
            }*/
        }

        private void listBoxComPorts_SelectedIndexChanged(object sender, EventArgs e)
        { /*
            if (listBoxComPorts.SelectedItem != null)
            {
                comPort = listBoxComPorts.SelectedItem.ToString();
            }*/
        }

        private void buttonSelectCom_Click(object sender, EventArgs e)
        { /*
            if (serialPort1.PortName == comPort) {
                return;
            }

            if (comPort == "UNDEFINED")
            {
                MessageBox.Show("No com port selected!");
            }
            else
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                
                serialPort1.PortName = comPort;
                serialPort1.Open();
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                buttonSend.Enabled = true;
                checkBoxIM.Enabled = true;
            }*/
        }

        private void buttonDisplaySensors_Click(object sender, EventArgs e)
        {
            this.Hide();
            SensorData sensData = new SensorData(this);
            sensData.Show();
        }
        /*
        public void closeSerialPort()
        {
            serialPort1.Close();
        }*/

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.Address = 9;
            packet.Type = Packet.Sensor_t.REED;
            packet.Sequence = 123;
            packet.ToACK();

            transmitACK(packet);
        }

        private void ButtonSelectCom2_Click(object sender, EventArgs e)
        {

        }
    }

}
