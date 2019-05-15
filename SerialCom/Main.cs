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
        private List<SerialCom> connections = new List<SerialCom>();

        public Main()
        {
            InitializeComponent();
            InitConnections();
            OpenConnections();
            displayConnections();
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxRX.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (SerialCom serialCom in connections)
            {
                if (serialCom.isOpen())
                {
                    serialCom.closePort();
                }
            }
        }


        private void buttonDisplaySensors_Click(object sender, EventArgs e)
        {
            this.Hide();
            SensorData sensData = new SensorData(this);
            sensData.Show();
        }
    }
}
